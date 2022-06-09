using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RatingController : ControllerBase
{
    private readonly Context _context;

    public RatingController(Context context)
    {
        _context = context;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Rating>>> GetRatings()
    {
        return await _context.Ratings.ToListAsync();
    }

    [HttpGet("{tconst}")]
    public async Task<ActionResult<Rating>> ShowRating(string tconst)
    {
        var rating = await _context.Ratings
            .Where(r => r.Tconst == tconst)
            .FirstOrDefaultAsync();

        return rating == null ? NotFound() : rating;
    }

    [HttpPost("")]
    public async Task<ActionResult<Rating>> StoreRating(Rating rating)
    {
        _context.Ratings.Add(rating);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRatings", new
        {
            tconst = rating.Tconst
        }, rating);
    }

    [HttpPut("{tconst}")]
    public async Task<IActionResult> PutRating(string tconst, Rating rating)
    {
        if (tconst != rating.Tconst)
        {
            return BadRequest();
        }

        _context.Entry(rating).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RatingExists(tconst))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{tconst}")]
    public async Task<IActionResult> DeleteRating(string tconst)
    {
        var rating = await _context.Ratings
            .Where(r => r.Tconst == tconst)
            .FirstOrDefaultAsync();

        if (rating == null)
        {
            return NotFound();
        }

        _context.Ratings.Remove(rating);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RatingExists(string tconst)
    {
        return _context.Ratings.Any(e => e.Tconst == tconst);
    }
}