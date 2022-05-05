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
    public class TypeAppliancesController : ControllerBase
    {
        private readonly DataContext _context;

        public TypeAppliancesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TypeAppliances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeAppliance>>> GetTypeAppliance()
        {
            return await _context.TypeAppliance.ToListAsync();
        }

        // GET: api/TypeAppliances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeAppliance>> GetTypeAppliance(int id)
        {
            var typeAppliance = await _context.TypeAppliance.FindAsync(id);

            if (typeAppliance == null)
            {
                return NotFound();
            }

            return typeAppliance;
        }

        // PUT: api/TypeAppliances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeAppliance(int id, TypeAppliance typeAppliance)
        {
            if (id != typeAppliance.TypeApp_ID)
            {
                return BadRequest();
            }

            _context.Entry(typeAppliance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeApplianceExists(id))
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

        // POST: api/TypeAppliances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeAppliance>> PostTypeAppliance(TypeAppliance typeAppliance)
        {
            _context.TypeAppliance.Add(typeAppliance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeAppliance", new { id = typeAppliance.TypeApp_ID }, typeAppliance);
        }

        // DELETE: api/TypeAppliances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeAppliance(int id)
        {
            var typeAppliance = await _context.TypeAppliance.FindAsync(id);
            if (typeAppliance == null)
            {
                return NotFound();
            }

            _context.TypeAppliance.Remove(typeAppliance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeApplianceExists(int id)
        {
            return _context.TypeAppliance.Any(e => e.TypeApp_ID == id);
        }
    }
}
