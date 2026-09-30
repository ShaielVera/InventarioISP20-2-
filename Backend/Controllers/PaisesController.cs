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
    public class PaisesController : ControllerBase
    {
        private readonly InventarioContext _context;

        public PaisesController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/Paises o api/Paises?filtro=arg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises([FromQuery] string? filtro)
        {
            var query = _context.Paises
                .Where(p => !p.IsDeleted); // Excluye registros eliminados

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(p => p.Name.ToLower().Contains(filtro.ToLower()));
            }

            return await query.OrderBy(p => p.Name).ToListAsync();
        }

        // GET: api/Paises/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Pais>>> GetDeleteds()
        {
            return await _context.Paises
                .IgnoreQueryFilters()
                .Where(p => p.IsDeleted) // Solo eliminados
                .ToListAsync();
        }

        // GET: api/Paises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(int id)
        {
            var pais = await _context.Paises
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        // GET: api/Paises/total
        [HttpGet("total")]
        public async Task<ActionResult<int>> GetTotalPaises()
        {
            return await _context.Paises.CountAsync(p => !p.IsDeleted);
        }

        // PUT: api/Paises/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(int id, Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del objeto.");
            }

            _context.Entry(pais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
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

        // PUT: api/Paises/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestorePais(int id)
        {
            var pais = await _context.Paises
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pais == null)
            {
                return NotFound();
            }

            pais.IsDeleted = false;
            _context.Entry(pais).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Paises
        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
            pais.IsDeleted = false;
            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPais", new { id = pais.Id }, pais);
        }

        // DELETE: api/Paises/5 (Borrado Lógico)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePais(int id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            pais.IsDeleted = true;
            _context.Entry(pais).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaisExists(int id)
        {
            return _context.Paises.Any(e => e.Id == id);
        }
    }
}