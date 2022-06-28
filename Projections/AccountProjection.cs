using MoviesAPI.Data;
using MoviesAPI.Events;
using MoviesAPI.Models;

namespace MoviesAPI.Projections;

public class AccountProjection
{
    public static async Task AddEvent(Context context, IEvent e, Account account)
    {
        switch (e)
        {
            case ChangedPlan changedPlan:
                await ApplyEvent(context, changedPlan, account);
                break;
            case RenewedPlan renewedPlan:
                await ApplyEvent(context, renewedPlan, account);
                break;
            default:
                throw new NotSupportedException();
        }
    }
    private static async Task ApplyEvent(Context context, ChangedPlan changedPlan, Account account)
    {
        changedPlan.Plan = account.Plan;
        await context.AccountEvents.AddAsync(new Projection()
        {
            ApiKey = changedPlan.ApiKey,
            Plan = changedPlan.Plan,
            RenewalDate = account.RenewalDate
        });

        await context.SaveChangesAsync();
    }

    private static async Task ApplyEvent(Context context, RenewedPlan renewedPlan, Account account)
    {
        renewedPlan.RenewalDate = account.RenewalDate;
        await context.AccountEvents.AddAsync(new Projection()
        {
            ApiKey = renewedPlan.ApiKey,
            Plan = account.Plan,
            RenewalDate = renewedPlan.RenewalDate
        });

        await context.SaveChangesAsync();
    }
}