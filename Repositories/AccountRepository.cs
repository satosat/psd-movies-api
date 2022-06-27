using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories;

public class AccountRepository : Repository
{
    public AccountRepository(Context context) : base(context)
    {
    }

    public async Task<ActionResult<Account>> Find(string apiKey)
    {
        var account = await GetContext().Accounts
            .FindAsync(apiKey);

        return account == null ? new NotFoundResult() : account;
    }

    public string Store()
    {
        var bytes = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(bytes);
        }

        var apiKey = BitConverter.ToString(bytes)
            .Replace("-", "")
            .ToLowerInvariant();
        
        Console.WriteLine(apiKey);

        var account = new Account()
        {
            ApiKey = apiKey,
            Plan = "Free",
            MonthlyCallsMade = 0
        };
        
        GetContext().Accounts.Add(account);
        GetContext().SaveChangesAsync();

        return account.ApiKey;
    }

    public async Task<IActionResult> Update(string apiKey, Account account)
    {
        if (apiKey != account.ApiKey)
        {
            return new BadRequestResult();
        }
        
        string[] plans = {"Free", "Silver", "Gold"};

        if (!plans.Contains(account.Plan))
        {
            return new BadRequestResult();
        }

        account.MonthlyCallsMade = 0;
        GetContext().Entry(account).State = EntityState.Modified;

        try
        {
            await GetContext().SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AccountExists(apiKey))
            {
                return new NotFoundResult();
            }

            throw;
        }

        return new NoContentResult();
    }
    
    private bool AccountExists(string apiKey)
    {
        return GetContext().Accounts.Any(e => e.ApiKey == apiKey);
    }
}