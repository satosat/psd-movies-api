using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class NameController : ControllerBase
{
    private readonly Context _context;

    public NameController(Context context)
    {
        _context = context;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<Name>>> Index()
    {
        return await _context.Names.ToListAsync();
    }

    [HttpGet("{nconst}")]
    public async Task<ActionResult<Name>> Show(string nconst)
    {
        var name = await _context.Names.FindAsync(nconst);

        return name == null ? NotFound() : name;
    }

    [HttpPost("")]
    public async Task<ActionResult<Name>> Store(Name name)
    {
        _context.Names.Add(name);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("Index", new
        {
            nconst = name.Nconst
        }, name);
    }

    [HttpPut("{nconst}")]
    public async Task<IActionResult> Update(string nconst, Name name)
    {
        if (nconst != name.Nconst)
        {
            return BadRequest();
        }

        _context.Entry(name).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)        
        {
            if (!NameExists(nconst))
            {
                return NotFound();
            }

            throw;
        }

        return NoContent();
    }

    [HttpDelete("{nconst}")]
    public async Task<IActionResult> Destroy(string nconst)
    {
        var name = await _context.Names.FindAsync(nconst);

        if (name == null)
        {
            return NotFound();
        }

        _context.Names.Remove(name);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool NameExists(string nconst)
    {
        return _context.Names.Any(e => e.Nconst == nconst);
    }   
}