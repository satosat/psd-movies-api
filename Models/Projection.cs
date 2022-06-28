namespace MoviesAPI.Models;

public class Projection
{
    public string ApiKey { get; set; } = null!;
    public string Plan { get; set; } = null!;
    public DateTime RenewalDate { get; set; }
}