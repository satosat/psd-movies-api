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
    public async Task<ActionResult<IEnumerable<Title>>> Index(string apiKey)
    {
        if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
        return await _repository.GetAll(apiKey);
    }

    [HttpGet("{tconst}")]
    public async Task<ActionResult<Title>> Show(string apiKey, string tconst)
    {
        if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
        return await _repository.Find(apiKey, tconst);
    }
}