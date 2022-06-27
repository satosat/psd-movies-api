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
}