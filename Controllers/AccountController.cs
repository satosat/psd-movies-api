using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Events;
using MoviesAPI.Models;
using MoviesAPI.Repositories;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AccountController : ControllerBase
{
    private readonly AccountRepository _repository;

    public AccountController(Context context)
    {
        _repository = new AccountRepository(context);
    }
    
    /** Perform new account creation mockup and return the API KEY
     *  Plan is "Free" as default
     * 
     */
    [HttpGet("CreateNewAccount")]
    public async Task<string> CreateNewAccount()
    {
        var API_KEY = await _repository.Store();
        return $"API_KEY: {API_KEY}";
    }

    /** Perform plan upgrade/downgrade mockup
     *  Payment is assumed to have succeeded
     *  
     */
    [HttpPost("RenewAccount")]
    public async Task<IActionResult> RenewAccount(string apiKey, Account account)
    {
        return await _repository.Update(apiKey, account, new RenewedPlan()
        {
            ApiKey = apiKey
        });
    }

    [HttpPost("ChangePlan")]
    public async Task<IActionResult> ChangePlan(string apiKey, Account account)
    {
        return await _repository.Update(apiKey, account, new ChangedPlan()
        {
            ApiKey = apiKey,
            Plan = account.Plan
        });
    }
}