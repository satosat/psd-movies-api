using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Repositories;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class NameController : ControllerBase, IModelController<Name>
{
    private readonly NameRepository _repository;

    public NameController(Context context)
    {
        _repository = new NameRepository(context);
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Name>>> Index(string apiKey)
    {
        if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
        return await _repository.GetAll(apiKey);
    }

    [HttpGet("{nconst}")]
    public async Task<ActionResult<Name>> Show(string apiKey, string nconst)
    {
        if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
        return await _repository.Find(apiKey, nconst);
    }
}