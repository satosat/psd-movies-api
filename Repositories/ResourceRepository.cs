using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories;

public class ResourceRepository : Repository
{
    private static readonly Dictionary<string, int> Plans = new()
    {
        {"Free", 500},
        {"Silver", 5000},
        {"Gold", 500000}
    };

    protected ResourceRepository(Context context) : base(context)
    {
    }

    /** Dummy implementation of an authorization middleware
     * 
     */
    protected async Task<bool> IsAuthorized(string apiKey)
    {
        if (!GetContext().Accounts.Any(e => e.ApiKey == apiKey))
        {
            return false;
        }
        
        var account = (Account) GetContext().Accounts.FindAsync(apiKey).Result!;

        if(account.MonthlyCallsMade >= Plans[account.Plan])
        {
            return false;
        }
        
        await IncrementCalls(account);
        return true;
    }

    private async Task<ActionResult> IncrementCalls(Account account)
    {
        account.MonthlyCallsMade += 1;
        await GetContext().SaveChangesAsync();

        return new NoContentResult();
    }
}