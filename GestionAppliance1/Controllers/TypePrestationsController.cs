#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionAppliance1.Data;
using GestionAppliance1.Models;

namespace GestionAppliance1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePrestationsController : ControllerBase
    {
        private readonly DataContext _context;

        public TypePrestationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TypePrestations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypePrestation>>> GetTypePrestation()
        {
            return await _context.TypePrestation.ToListAsync();
        }

        // GET: api/TypePrestations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypePrestation>> GetTypePrestation(int id)
        {
            var typePrestation = await _context.TypePrestation.FindAsync(id);

            if (typePrestation == null)
            {
                return NotFound();
            }

            return typePrestation;
        }

        // PUT: api/TypePrestations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypePrestation(int id, TypePrestation typePrestation)
        {
            if (id != typePrestation.TypePrestation_ID)
            {
                return BadRequest();
            }

            _context.Entry(typePrestation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypePrestationExists(id))
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

        // POST: api/TypePrestations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypePrestation>> PostTypePrestation(TypePrestation typePrestation)
        {
            _context.TypePrestation.Add(typePrestation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypePrestation", new { id = typePrestation.TypePrestation_ID }, typePrestation);
        }

        // DELETE: api/TypePrestations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypePrestation(int id)
        {
            var typePrestation = await _context.TypePrestation.FindAsync(id);
            if (typePrestation == null)
            {
                return NotFound();
            }

            _context.TypePrestation.Remove(typePrestation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypePrestationExists(int id)
        {
            return _context.TypePrestation.Any(e => e.TypePrestation_ID == id);
        }
    }
}
