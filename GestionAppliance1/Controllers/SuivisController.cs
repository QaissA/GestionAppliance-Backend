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
    public class SuivisController : ControllerBase
    {
        private readonly DataContext _context;

        public SuivisController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Suivis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suivi>>> GetSuivi()
        {
            return await _context.Suivi.ToListAsync();
        }

        // GET: api/Suivis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suivi>> GetSuivi(int id)
        {
            var suivi = await _context.Suivi.FindAsync(id);

            if (suivi == null)
            {
                return NotFound();
            }

            return suivi;
        }

        // PUT: api/Suivis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuivi(int id, Suivi suivi)
        {
            if (id != suivi.Suivi_ID)
            {
                return BadRequest();
            }

            _context.Entry(suivi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuiviExists(id))
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

        // POST: api/Suivis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Suivi>> PostSuivi(Suivi suivi)
        {
            _context.Suivi.Add(suivi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuivi", new { id = suivi.Suivi_ID }, suivi);
        }

        // DELETE: api/Suivis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuivi(int id)
        {
            var suivi = await _context.Suivi.FindAsync(id);
            if (suivi == null)
            {
                return NotFound();
            }

            _context.Suivi.Remove(suivi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuiviExists(int id)
        {
            return _context.Suivi.Any(e => e.Suivi_ID == id);
        }
    }
}
