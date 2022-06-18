using Microsoft.AspNetCore.JsonPatch.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories;

public class RatingRepository : ModelRepository, IModelRepository<Rating>
{
    public RatingRepository(Context context) : base(context)
    {
    }

    public async Task<ActionResult<IEnumerable<Rating>>> GetAll()
    {
        return await GetContext().Ratings.ToListAsync();
    }

    public async Task<ActionResult<Rating>> Find(string tconst)
    {
        var rating = await GetContext().Ratings.FindAsync(tconst);

        if (rating == null)
        {
            return new NotFoundResult();
        }

        return rating;
    }

    public async Task<ActionResult<Rating>> Store(Rating rating)
    {
        if (!GetContext().Titles.Any(e => e.Tconst == rating.Tconst))
        {
            return new BadRequestResult();
        }

        GetContext().Ratings.Add(rating);
        await GetContext().SaveChangesAsync();

        return new CreatedAtActionResult("Index", "Rating",
            new
            {
                tconst = rating.Tconst
            }, rating);
    }

    public async Task<ActionResult> Update(string tconst, Rating rating)
    {
        if (tconst != rating.Tconst)
        {
            return new BadRequestResult();
        }

        GetContext().Entry(rating).State = EntityState.Modified;

        try
        {
            await GetContext().SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RatingExists(tconst))
            {
                return new NotFoundResult();
            }
            throw;
        }

        return new NoContentResult();
    }

    public async Task<IActionResult> Destroy(string tconst)
    {
        var rating = await GetContext().Ratings.FindAsync(tconst);

        if (rating == null)
        {
            return new NotFoundResult();
        }
        
        GetContext().Ratings.Remove(rating);
        await GetContext().SaveChangesAsync();

        return new NoContentResult();
    }

    private bool RatingExists(string tconst)
    {
        return GetContext().Ratings.Any(e => e.Tconst == tconst);
    }
}