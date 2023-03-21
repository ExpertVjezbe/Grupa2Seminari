using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seminar2.FraneGregov.Seminar2;

namespace Seminar2.FraneGregov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradovisController : ControllerBase
    {
        private readonly Seminar2Context _context;

        public GradovisController(Seminar2Context context)
        {
            _context = context;
        }

        // GET: api/Gradovis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gradovi>>> GetGradovis()
        {
            return await _context.Gradovis.ToListAsync();
        }

        // GET: api/Gradovis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gradovi>> GetGradovi(int id)
        {
            var gradovi = await _context.Gradovis.FindAsync(id);

            if (gradovi == null)
            {
                return NotFound();
            }

            return gradovi;
        }

        // PUT: api/Gradovis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradovi(int id, Gradovi gradovi)
        {
            if (id != gradovi.Id)
            {
                return BadRequest();
            }

            _context.Entry(gradovi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradoviExists(id))
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

        // POST: api/Gradovis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gradovi>> PostGradovi(Gradovi gradovi)
        {
            _context.Gradovis.Add(gradovi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGradovi", new { id = gradovi.Id }, gradovi);
        }

        // DELETE: api/Gradovis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradovi(int id)
        {
            var gradovi = await _context.Gradovis.FindAsync(id);
            if (gradovi == null)
            {
                return NotFound();
            }

            _context.Gradovis.Remove(gradovi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GradoviExists(int id)
        {
            return _context.Gradovis.Any(e => e.Id == id);
        }
    }
}
