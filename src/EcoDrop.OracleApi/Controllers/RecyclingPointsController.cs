using EcoDrop.Domain.Entities;
using EcoDrop.Infrastructure.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoDrop.OracleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecyclingPointsController : ControllerBase
{
    private readonly EcoDropOracleContext _context;

    public RecyclingPointsController(EcoDropOracleContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecyclingPoint>>> GetAll()
    {
        return await _context.RecyclingPoints
            .Include(r => r.Materials)
            .ThenInclude(m => m.MaterialType)
            .Include(r => r.OpeningHours)
            .ToListAsync();
    }

   
    [HttpGet("{id}")]
    public async Task<ActionResult<RecyclingPoint>> GetById(int id)
    {
        var point = await _context.RecyclingPoints
            .Include(r => r.Materials)
            .ThenInclude(m => m.MaterialType)
            .Include(r => r.OpeningHours)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (point == null) return NotFound();
        return point;
    }

   
    [HttpPost]
    public async Task<ActionResult<RecyclingPoint>> Create(RecyclingPoint recyclingPoint)
    {
        _context.RecyclingPoints.Add(recyclingPoint);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = recyclingPoint.Id }, recyclingPoint);
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RecyclingPoint recyclingPoint)
    {
        if (id != recyclingPoint.Id) return BadRequest();

        _context.Entry(recyclingPoint).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var point = await _context.RecyclingPoints.FindAsync(id);
        if (point == null) return NotFound();

        _context.RecyclingPoints.Remove(point);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
