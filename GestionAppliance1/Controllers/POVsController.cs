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
    public class POVsController : ControllerBase
    {
        private readonly DataContext _context;

        public POVsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/POVs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<POV>>> GetPOV()
        {
            return await _context.POV.ToListAsync();
        }

        // GET: api/POVs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<POV>> GetPOV(int id)
        {
            var pOV = await _context.POV.FindAsync(id);

            if (pOV == null)
            {
                return NotFound();
            }

            return pOV;
        }

        // PUT: api/POVs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPOV(int id, POV pOV)
        {
            if (id != pOV.POV_Id)
            {
                return BadRequest();
            }

            _context.Entry(pOV).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!POVExists(id))
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

        // POST: api/POVs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<POV>> PostPOV(POV pOV)
        {
            _context.POV.Add(pOV);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPOV", new { id = pOV.POV_Id }, pOV);
        }

        // DELETE: api/POVs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePOV(int id)
        {
            var pOV = await _context.POV.FindAsync(id);
            if (pOV == null)
            {
                return NotFound();
            }

            _context.POV.Remove(pOV);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool POVExists(int id)
        {
            return _context.POV.Any(e => e.POV_Id == id);
        }
    }
}
