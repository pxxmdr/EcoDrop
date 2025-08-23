using EcoDrop.Domain.Entities;
using EcoDrop.Infrastructure.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoDrop.OracleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialTypesController : ControllerBase
    {
        private readonly EcoDropOracleContext _context;

        public MaterialTypesController(EcoDropOracleContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialType>>> GetAll()
        {
            return await _context.MaterialTypes.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialType>> GetById(int id)
        {
            var material = await _context.MaterialTypes.FindAsync(id);

            if (material == null)
                return NotFound();

            return material;
        }

        [HttpPost]
        public async Task<ActionResult<MaterialType>> Create(MaterialType materialType)
        {
            _context.MaterialTypes.Add(materialType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = materialType.Id }, materialType);
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MaterialType materialType)
        {
            if (id != materialType.Id)
                return BadRequest();

            _context.Entry(materialType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.MaterialTypes.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var material = await _context.MaterialTypes.FindAsync(id);
            if (material == null)
                return NotFound();

            _context.MaterialTypes.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
