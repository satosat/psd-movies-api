using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories;

public class NameRepository : ResourceRepository, IResourceRepository<Name>
{
    public NameRepository(Context context) : base(context)
    {
    }
    
    public async Task<ActionResult<IEnumerable<Name>>> GetAll(string apiKey)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        return await GetContext().Names.ToListAsync();
    }

    public async Task<ActionResult<Name>> Find(string apiKey, string nconst)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        
        var name = await GetContext().Names
            .FindAsync(nconst);

        return name == null ? new NotFoundResult() : name;
    }
}