using Backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesController : ControllerBase
    {
        private readonly InventarioContext _context;

        public LocalidadesController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/Localidades o api/Localidades?filtro=rosario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localidad>>> GetLocalidades([FromQuery] string? filtro)
        {
            var query = _context.Localidades
                .Include(l => l.Provincia)
                .ThenInclude(p => p.Pais)
                .Where(l => !l.IsDeleted); // Excluye registros eliminados

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(l => l.Name.ToLower().Contains(filtro.ToLower()));
            }

            return await query.OrderBy(l => l.Name).ToListAsync();
        }

        // GET: api/Localidades/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Localidad>>> GetDeleteds()
        {
            return await _context.Localidades
                .IgnoreQueryFilters()
                .Include(l => l.Provincia)
                .ThenInclude(p => p.Pais)
                .Where(l => l.IsDeleted)
                .ToListAsync();
        }

        // GET: api/Localidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Localidad>> GetLocalidad(int id)
        {
            var localidad = await _context.Localidades
                .Include(l => l.Provincia)
                .ThenInclude(p => p.Pais)
                .FirstOrDefaultAsync(l => l.Id == id && !l.IsDeleted);

            if (localidad == null)
            {
                return NotFound();
            }

            return localidad;
        }

        // GET: api/Localidades/total
        [HttpGet("total")]
        public async Task<ActionResult<int>> GetTotalLocalidades()
        {
            return await _context.Localidades.CountAsync(l => !l.IsDeleted);
        }

        // PUT: api/Localidades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalidad(int id, Localidad localidad)
        {
            if (id != localidad.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del objeto.");
            }

            _context.Entry(localidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalidadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Localidades/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreLocalidad(int id)
        {
            var localidad = await _context.Localidades
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(l => l.Id == id);

            if (localidad == null)
            {
                return NotFound();
            }

            localidad.IsDeleted = false;
            _context.Entry(localidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Localidades
        [HttpPost]
        public async Task<ActionResult<Localidad>> PostLocalidad(Localidad localidad)
        {
            localidad.IsDeleted = false;
            _context.Localidades.Add(localidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalidad", new { id = localidad.Id }, localidad);
        }

        // DELETE: api/Localidades/5 (Borrado Lógico)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalidad(int id)
        {
            var localidad = await _context.Localidades.FindAsync(id);
            if (localidad == null)
            {
                return NotFound();
            }

            localidad.IsDeleted = true;
            _context.Entry(localidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocalidadExists(int id)
        {
            return _context.Localidades.Any(e => e.Id == id);
        }
    }
}