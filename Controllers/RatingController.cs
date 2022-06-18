using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Repositories;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RatingController : ControllerBase
{
    private readonly RatingRepository _ratingRepository;

    public RatingController(Context context)
    {
        _ratingRepository = new RatingRepository(context);
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Rating>>> Index()
    {
        return await _ratingRepository.GetAll();
    }

    [HttpGet("{tconst}")]
    public async Task<ActionResult<Rating>> Show(string tconst)
    {
        return await _ratingRepository.Find(tconst);
    }

    [HttpPost("")]
    public async Task<ActionResult<Rating>> Store(Rating rating)
    {
        return await _ratingRepository.Store(rating);
    }

    [HttpPut("{tconst}")]
    public async Task<IActionResult> Update(string tconst, Rating rating)
    {
        return await _ratingRepository.Update(tconst, rating);
    }

    [HttpDelete("{tconst}")]
    public async Task<IActionResult> Destroy(string tconst)
    {
        return await _ratingRepository.Destroy(tconst);
    }
}