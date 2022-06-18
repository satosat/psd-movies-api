using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Repositories;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class NameController : ControllerBase
{
    private readonly NameRepository _repository;

    public NameController(Context context)
    {
        _repository = new NameRepository(context);
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Name>>> Index()
    {
        return await _repository.GetAll();
    }

    [HttpGet("{nconst}")]
    public async Task<ActionResult<Name>> Show(string nconst)
    {
        return await _repository.Find(nconst);
    }

    [HttpPost("")]
    public async Task<ActionResult<Name>> Store(Name name)
    {
        return await _repository.Store(name);
    }

    [HttpPut("{nconst}")]
    public async Task<IActionResult> Update(string nconst, Name name)
    {
        return await _repository.Update(nconst, name);
    }

    [HttpDelete("{nconst}")]
    public async Task<IActionResult> Destroy(string nconst)
    {
        return await _repository.Destroy(nconst);
    }
}