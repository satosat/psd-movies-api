using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using MoviesAPI.Data;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class WorkController : ControllerBase
{
    private readonly Context _context;

    public WorkController(Context context)
    {
        _context = context;
    }

    [HttpGet("Movies/{nconst}")]
    public async Task<ActionResult<IEnumerable<Title>>> GetWorks(string nconst)
    {
        return await _context.Works
            .FromSqlRaw("CALL GetWorksByNconst({0})", nconst)
            .ToListAsync();
    }

    [HttpGet("Casts/{tconst}")]
    public async Task<ActionResult<IEnumerable<Cast>>> GetCasts(string tconst)
    {
        return await _context.Casts
            .FromSqlRaw("CALL GetCastsByTconst({0})", tconst)
            .ToListAsync();
    }
}