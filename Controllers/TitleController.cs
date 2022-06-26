using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Repositories;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TitleController : ControllerBase, IModelController<Title>
{
    private readonly TitleRepository _repository;

    public TitleController(Context context)
    {
        _repository = new TitleRepository(context);
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Title>>> Index()
    {
        return await _repository.GetAll();
    }

    [HttpGet("{tconst}")]
    public async Task<ActionResult<Title>> Show(string tconst)
    {
        return await _repository.Find(tconst);
    }

    [HttpPost("")]
    public async Task<ActionResult<Title>> Store(Title title)
    {
        return await _repository.Store(title);
    }

    [HttpPut("{tconst}")]
    public async Task<IActionResult> Update(string tconst, Title title)
    {
        return await _repository.Update(tconst, title);
    }

    [HttpDelete("{tconst}")]
    public async Task<IActionResult> Destroy(string tconst)
    {
        return await _repository.Destroy(tconst);
    }
}