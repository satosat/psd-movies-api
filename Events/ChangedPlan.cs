namespace MoviesAPI.Events;

public class ChangedPlan : IEvent
{
    public string ApiKey { get; set; }
    public string Plan { get; set; }
}