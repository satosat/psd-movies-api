using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Repositories;

public class RatingRepository : ResourceRepository, IResourceRepository<Rating>
{
    public RatingRepository(Context context) : base(context)
    {
    }

    public async Task<ActionResult<IEnumerable<Rating>>> GetAll(string apiKey)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        
        return await GetContext().Ratings.ToListAsync();
    }

    public async Task<ActionResult<Rating>> Find(string apiKey, string tconst)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        
        var rating = await GetContext().Ratings.FindAsync(tconst);

        if (rating == null)
        {
            return new NotFoundResult();
        }

        return rating;
    }

    public async Task<ActionResult<Rating>> Store(string apiKey, Rating rating)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        
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

    public async Task<ActionResult> Update(string apiKey, string tconst, Rating rating)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        
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

    public async Task<IActionResult> Destroy(string apiKey, string tconst)
    {
        if (!IsAuthorized(apiKey).Result)
        {
            return new BadRequestResult();
        }
        
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