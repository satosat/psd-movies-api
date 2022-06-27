using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories;

public class ResourceRepository : Repository
{
    private readonly AccountRepository _accountRepository;
    private static readonly Dictionary<string, int> Plans = new()
    {
        {"Free", 500},
        {"Silver", 5000},
        {"Gold", 500000}
    };
    
    public ResourceRepository(Context context) : base(context)
    {
        _accountRepository = new AccountRepository(context);
    }

    protected bool IsAuthorized(string apiKey)
    {
        if (!GetContext().Accounts.Any(e => e.ApiKey == apiKey))
        {
            return false;
        }
        
        var account = (Account) GetContext().Accounts.FindAsync(apiKey).Result!;

        return account.MonthlyCallsMade <= Plans[account.Plan];
    }
}