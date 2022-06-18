using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using MoviesAPI.Data;
using MoviesAPI.Repositories;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class WorkController : ControllerBase
{
    private readonly WorkRepository _workRepository;

    public WorkController(Context context)
    {
        _workRepository = new WorkRepository(context);
    }

    [HttpGet("Movies/{nconst}")]
    public async Task<ActionResult<IEnumerable<Title>>> GetWorks(string nconst)
    {
        return await _workRepository.GetWorks(nconst);
    }

    [HttpGet("Casts/{tconst}")]
    public async Task<ActionResult<IEnumerable<Cast>>> GetCasts(string tconst)
    {
        return await _workRepository.GetCasts(tconst);
    }
}