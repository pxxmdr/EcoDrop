using EcoDrop.Domain.Entities;
using EcoDrop.Infrastructure.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoDrop.OracleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecyclingPointMaterialsController : ControllerBase
    {
        private readonly EcoDropOracleContext _context;

        public RecyclingPointMaterialsController(EcoDropOracleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecyclingPointMaterialType>>> GetAll()
        {
            return await _context.RecyclingPointMaterials.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<RecyclingPointMaterialType>> Create(RecyclingPointMaterialType entity)
        {
            _context.RecyclingPointMaterials.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), entity);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int recyclingPointId, int materialTypeId)
        {
            var entity = await _context.RecyclingPointMaterials
                                       .FirstOrDefaultAsync(r => r.RecyclingPointId == recyclingPointId &&
                                                                 r.MaterialTypeId == materialTypeId);
            if (entity == null) return NotFound();

            _context.RecyclingPointMaterials.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
