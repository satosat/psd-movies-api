using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Events;
using MoviesAPI.Models;
using MoviesAPI.Projections;

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

    public async Task<string> Store()
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
            MonthlyCallsMade = 0,
            RenewalDate = DateTime.Now
        };
        
        GetContext().Accounts.Add(account);
        await GetContext().SaveChangesAsync();

        return apiKey;
    }

    public async Task<IActionResult> Update(string apiKey, Account account, IEvent e)
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

        try
        {
            account.MonthlyCallsMade = 0;
            account.RenewalDate = DateTime.Now;
            GetContext().Entry(account).State = EntityState.Modified;
            await GetContext().SaveChangesAsync();

            await AccountProjection.AddEvent(GetContext(), e, account);
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