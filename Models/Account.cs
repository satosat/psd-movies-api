namespace MoviesAPI.Models;

public class Account
{
    public string ApiKey { get; set; } = null!;
    public string Plan { get; set; } = null!;
    public int MonthlyCallsMade { get; set; } 
}