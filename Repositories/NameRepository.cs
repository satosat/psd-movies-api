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

    public async Task<ActionResult<Name>> Store(string apiKey, Name name)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        
        GetContext().Names.Add(name);
        await GetContext().SaveChangesAsync();

        return new CreatedAtActionResult("Index", "Name",
            new
            {
                nconst = name.Nconst
            }, name);
    }

    public async Task<ActionResult> Update(string apiKey, string nconst, Name name)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        
        if (nconst != name.Nconst)
        {
            return new BadRequestResult();
        }
        
        GetContext().Entry(name).State = EntityState.Modified;

        try
        {
            await GetContext().SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NameExists(nconst))
            {
                return new NotFoundResult();
            }

            throw;
        }

        return new NoContentResult();
    }

    public async Task<IActionResult> Destroy(string apiKey, string nconst)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        
        var name = await GetContext().Names.FindAsync(nconst);

        if (name == null)
        {
            return new NotFoundResult();
        }

        GetContext().Names.Remove(name);
        await GetContext().SaveChangesAsync();

        return new NoContentResult();
    }

    private bool NameExists(string nconst)
    {
        return GetContext().Names.Any(e => e.Nconst == nconst);
    }  
}