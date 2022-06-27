using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories;

public class TitleRepository : Repository, IModelRepository<Title>
{
    public TitleRepository(Context context) : base(context)
    {
    }

    public async Task<ActionResult<IEnumerable<Title>>> GetAll(string apiKey)
    {
        return await GetContext().Titles.ToListAsync();
    }

    public async Task<ActionResult<Title>> Find(string tconst)
    {
        var title = await GetContext().Titles.FindAsync(tconst);

        if (title == null)
        {
            return new NotFoundResult();
        }

        return title;
    }

    public async Task<ActionResult<Title>> Store(Title title)
    {
        GetContext().Titles.Add(title);
        await GetContext().SaveChangesAsync();

        return new CreatedAtActionResult("Index", "Title",
            new
            {
                tconst = title.Tconst
            }, title);
    }

    public async Task<ActionResult> Update(string tconst, Title title)
    {
        if (tconst != title.Tconst)
        {
            return new BadRequestResult();
        }
        GetContext().Entry(title).State = EntityState.Modified;

        try
        {
            await GetContext().SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TitleExists(tconst))
            {
                return new NotFoundResult();
            }
            throw;
        }

        return new NoContentResult();
    }

    public async Task<IActionResult> Destroy(string tconst)
    {
        var title = await GetContext().Titles.FindAsync(tconst);

        if (title == null)
        {
            return new NotFoundResult();
        }

        GetContext().Titles.Remove(title);
        await GetContext().SaveChangesAsync();

        return new NoContentResult();
    }

    private bool TitleExists(string tconst)
    {
        return GetContext().Titles.Any(e => e.Tconst == tconst);
    }
}