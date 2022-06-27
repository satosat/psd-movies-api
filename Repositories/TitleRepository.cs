using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories;

public class TitleRepository : ResourceRepository, IResourceRepository<Title>
{
    public TitleRepository(Context context) : base(context)
    {
    }

    public async Task<ActionResult<IEnumerable<Title>>> GetAll(string apiKey)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        
        return await GetContext().Titles.ToListAsync();
    }

    public async Task<ActionResult<Title>> Find(string apiKey, string tconst)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        
        var title = await GetContext().Titles.FindAsync(tconst);

        if (title == null)
        {
            return new NotFoundResult();
        }

        return title;
    }
}