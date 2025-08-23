using EcoDrop.Domain.Entities;
using EcoDrop.Infrastructure.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoDrop.OracleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpeningHoursController : ControllerBase
    {
        private readonly EcoDropOracleContext _context;

        public OpeningHoursController(EcoDropOracleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpeningHour>>> GetAll()
        {
            return await _context.OpeningHours.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OpeningHour>> GetById(int id)
        {
            var hour = await _context.OpeningHours.FindAsync(id);
            if (hour == null) return NotFound();
            return hour;
        }

        [HttpPost]
        public async Task<ActionResult<OpeningHour>> Create(OpeningHour openingHour)
        {
            _context.OpeningHours.Add(openingHour);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = openingHour.Id }, openingHour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OpeningHour openingHour)
        {
            if (id != openingHour.Id) return BadRequest();
            _context.Entry(openingHour).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hour = await _context.OpeningHours.FindAsync(id);
            if (hour == null) return NotFound();
            _context.OpeningHours.Remove(hour);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
