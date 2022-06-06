using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TitleController : ControllerBase
{
    private readonly MoviesAPIContext _context;

    public TitleController(MoviesAPIContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Title>>> GetTitles()
    {
        return await _context.Titles.ToListAsync();
    }

    [HttpGet("{tconst}")]
    public async Task<ActionResult<Title>> ShowTitle(string tconst)
    {
        var title = await _context.Titles.FindAsync(tconst);

        return title == null ? NotFound() : title;
    }

    [HttpPost("")]
    public async Task<ActionResult<Title>> StoreTitle(Title title)
    {
        _context.Titles.Add(title);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTitles", new
        {
            tconst = title.Tconst
        }, title);
    }

    [HttpPut("{tconst}")]
    public async Task<IActionResult> PutTitle(string tconst, Title title)
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
        catch (DbUpdateConcurrencyException e)
        {
            Console.WriteLine(e);
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{tconst}")]
    public async Task<IActionResult> DeleteTitle(string tconst)
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
}