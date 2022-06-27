using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Repositories;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RatingController : ControllerBase, IModelController<Rating>
{
    private readonly RatingRepository _ratingRepository;

    public RatingController(Context context)
    {
        _ratingRepository = new RatingRepository(context);
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Rating>>> Index(string apiKey)
    {
        if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
        return await _ratingRepository.GetAll(apiKey);
    }

    [HttpGet("{tconst}")]
    public async Task<ActionResult<Rating>> Show(string apiKey, string tconst)
    {
        if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
        return await _ratingRepository.Find(apiKey, tconst);
    }

    [HttpPost("")]
    public async Task<ActionResult<Rating>> Store(string apiKey, Rating rating)
    {
        if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
        return await _ratingRepository.Store(apiKey, rating);
    }

    [HttpPut("{tconst}")]
    public async Task<IActionResult> Update(string apiKey, string tconst, Rating rating)
    {
        if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
        return await _ratingRepository.Update(apiKey, tconst, rating);
    }

    [HttpDelete("{tconst}")]
    public async Task<IActionResult> Destroy(string apiKey, string tconst)
    {
        if (apiKey == null) throw new ArgumentNullException(nameof(apiKey));
        return await _ratingRepository.Destroy(apiKey, tconst);
    }
}