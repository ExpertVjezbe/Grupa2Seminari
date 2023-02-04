using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seminar2.IvicaHorvat.Seminar2;

namespace Seminar2.IvicaHorvat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrzavesController : ControllerBase
    {
        private readonly Seminar2Context _context;

        public DrzavesController(Seminar2Context context)
        {
            _context = context;
        }

        // GET: api/Drzaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drzave>>> GetDrzaves()
        {
          if (_context.Drzaves == null)
          {
              return NotFound();
          }
            return await _context.Drzaves.ToListAsync();
        }

        // GET: api/Drzaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drzave>> GetDrzave(int id)
        {
          if (_context.Drzaves == null)
          {
              return NotFound();
          }
            var drzave = await _context.Drzaves.FindAsync(id);

            if (drzave == null)
            {
                return NotFound();
            }

            return drzave;
        }

        // PUT: api/Drzaves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrzave(int id, Drzave drzave)
        {
            if (id != drzave.Id)
            {
                return BadRequest();
            }

            _context.Entry(drzave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrzaveExists(id))
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

        // POST: api/Drzaves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drzave>> PostDrzave(Drzave drzave)
        {
          if (_context.Drzaves == null)
          {
              return Problem("Entity set 'Seminar2Context.Drzaves'  is null.");
          }
            _context.Drzaves.Add(drzave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrzave", new { id = drzave.Id }, drzave);
        }

        // DELETE: api/Drzaves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrzave(int id)
        {
            if (_context.Drzaves == null)
            {
                return NotFound();
            }
            var drzave = await _context.Drzaves.FindAsync(id);
            if (drzave == null)
            {
                return NotFound();
            }

            _context.Drzaves.Remove(drzave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrzaveExists(int id)
        {
            return (_context.Drzaves?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
