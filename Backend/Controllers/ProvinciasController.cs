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
    public class ProvinciasController : ControllerBase
    {
        private readonly InventarioContext _context;

        public ProvinciasController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/Provincias o api/Provincias?filtro=santa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provincia>>> GetProvincias([FromQuery] string? filtro)
        {
            var query = _context.Provincias
                .Include(p => p.Pais)
                .Where(p => !p.IsDeleted); // Excluye registros eliminados

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(p => p.Name.ToLower().Contains(filtro.ToLower()));
            }

            return await query.OrderBy(p => p.Name).ToListAsync();
        }

        // GET: api/Provincias/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Provincia>>> GetDeleteds()
        {
            return await _context.Provincias
                .IgnoreQueryFilters()
                .Include(p => p.Pais)
                .Where(p => p.IsDeleted) // Solo eliminados
                .ToListAsync();
        }

        // GET: api/Provincias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provincia>> GetProvincia(int id)
        {
            var provincia = await _context.Provincias
                .Include(p => p.Pais)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (provincia == null)
            {
                return NotFound();
            }

            return provincia;
        }

        // GET: api/Provincias/total
        [HttpGet("total")]
        public async Task<ActionResult<int>> GetTotalProvincias()
        {
            return await _context.Provincias.CountAsync(p => !p.IsDeleted);
        }

        // PUT: api/Provincias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvincia(int id, Provincia provincia)
        {
            if (id != provincia.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del objeto.");
            }

            _context.Entry(provincia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinciaExists(id))
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

        // PUT: api/Provincias/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreProvincia(int id)
        {
            var provincia = await _context.Provincias
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (provincia == null)
            {
                return NotFound();
            }

            provincia.IsDeleted = false;
            _context.Entry(provincia).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Provincias
        [HttpPost]
        public async Task<ActionResult<Provincia>> PostProvincia(Provincia provincia)
        {
            provincia.IsDeleted = false;
            _context.Provincias.Add(provincia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvincia", new { id = provincia.Id }, provincia);
        }

        // DELETE: api/Provincias/5 (Borrado Lógico)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvincia(int id)
        {
            var provincia = await _context.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }

            provincia.IsDeleted = true;
            _context.Entry(provincia).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProvinciaExists(int id)
        {
            return _context.Provincias.Any(e => e.Id == id);
        }
    }
}