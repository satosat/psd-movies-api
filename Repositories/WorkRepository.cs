using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories;

public class WorkRepository : Repository
{
    private readonly string _getWorksQuery = "CALL GetWorksByNconst({0})";
    private readonly string _getCastsQuery = "CALL GetCastsByTconst({0})";
    
    public WorkRepository(Context context) : base(context)
    {
    }

    public async Task<ActionResult<IEnumerable<Title>>> GetWorks(string nconst)
    {
        return await GetContext().Works
            .FromSqlRaw(_getWorksQuery, nconst)
            .ToListAsync();
    }

    public async Task<ActionResult<IEnumerable<Cast>>> GetCasts(string tconst)
    {
        return await GetContext().Casts
            .FromSqlRaw(_getCastsQuery, tconst)
            .ToListAsync();
    }
}