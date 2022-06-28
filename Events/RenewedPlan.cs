namespace MoviesAPI.Events;

public class RenewedPlan : IEvent
{
    public string ApiKey { get; set; }
    public DateTime RenewalDate { get; set; }
}