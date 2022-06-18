using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories;

public class NameRepository : ModelRepository, IModelRepository<Name>
{
    public NameRepository(Context context) : base(context)
    {
    }
    
    public async Task<ActionResult<IEnumerable<Name>>> GetAll()
    {
        return await GetContext().Names.ToListAsync();
    }

    public async Task<ActionResult<Name>> Find(string nconst)
    {
        var name = await GetContext().Names
            .FindAsync(nconst);

        return name == null ? new NotFoundResult() : name;
    }

    public async Task<ActionResult<Name>> Store(Name name)
    {
        GetContext().Names.Add(name);
        await GetContext().SaveChangesAsync();

        return new CreatedAtActionResult("Index", "Name",
            new
            {
                nconst = name.Nconst
            }, name);
    }

    public async Task<ActionResult> Update(string nconst, Name name)
    {
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

    public async Task<IActionResult> Destroy(string nconst)
    {
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