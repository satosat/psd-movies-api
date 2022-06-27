using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
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
    public string CreateNewAccount()
    {
        return $"API_KEY: {_repository.Store()}";
    }

    /** Perform plan upgrade/downgrade mockup
     *  Payment is assumed to have succeeded
     *  
     */
    [HttpPut("{apiKey}")]
    public async Task<IActionResult> Update(string apiKey, Account account)
    {
        return await _repository.Update(apiKey, account);
    }
}