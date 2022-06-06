using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Procedures;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class WorkController : ControllerBase
{
    private readonly MoviesDbContextProcedures _contextProcedures;

    public WorkController(MoviesDbContextProcedures contextProcedures)
    {
        _contextProcedures = contextProcedures;
    }

    [HttpGet("{nconst}")]
    public async Task<ActionResult<IEnumerable<Work>>> GetWorks(string nconst)
    {
        return await _contextProcedures.Works
            .FromSqlRaw("CALL GetWorksByNconst({0})", nconst)
            .ToListAsync();
    }
}