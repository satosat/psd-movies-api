using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TitleController : ControllerBase
{
    private readonly Context _context;

    public TitleController(Context context)
    {
        _context = context;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Title>>> Index()
    {
        return await _context.Titles.ToListAsync();
    }

    [HttpGet("{tconst}")]
    public async Task<ActionResult<Title>> Show(string tconst, bool ratings)
    {
        var title = await _context.Titles.FindAsync(tconst);

        return title == null ? NotFound() : title;
    }

    [HttpPost("")]
    public async Task<ActionResult<Title>> Store(Title title)
    {
        _context.Titles.Add(title);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Index", new
        {
            tconst = title.Tconst
        }, title);
    }

    [HttpPut("{tconst}")]
    public async Task<IActionResult> Update(string tconst, Title title)
    {
        if (tconst != title.Tconst)
        {
            return BadRequest();
        }

        _context.Entry(title).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }   
        catch (DbUpdateConcurrencyException)
        {
            if (!TitleExists(tconst))
            {
                return NotFound();
            }
            
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{tconst}")]
    public async Task<IActionResult> Destroy(string tconst)
    {
        var title = await _context.Titles.FindAsync(tconst);

        if (title == null)
        {
            return NotFound();
        }

        _context.Titles.Remove(title);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TitleExists(string tconst)
    {
        return _context.Titles.Any(e => e.Tconst == tconst);
    }
}