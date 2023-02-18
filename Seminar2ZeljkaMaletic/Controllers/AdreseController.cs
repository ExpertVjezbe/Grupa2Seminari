using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seminar2ZeljkaMaletic.Database;

namespace Seminar2ZeljkaMaletic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdreseController : ControllerBase
    {
        private readonly Seminar2Context _context;

        public AdreseController(Seminar2Context context)
        {
            _context = context;
        }

        // GET: api/Adrese
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adrese>>> GetAdreses()
        {
          if (_context.Adreses == null)
          {
              return NotFound();
          }
            return await _context.Adreses.ToListAsync();
        }

        // GET: api/Adrese/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adrese>> GetAdrese(int id)
        {
          if (_context.Adreses == null)
          {
              return NotFound();
          }
            var adrese = await _context.Adreses.FindAsync(id);

            if (adrese == null)
            {
                return NotFound();
            }

            return adrese;
        }

        // PUT: api/Adrese/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdrese(int id, Adrese adrese)
        {
            if (id != adrese.Id)
            {
                return BadRequest();
            }

            _context.Entry(adrese).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdreseExists(id))
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

        // POST: api/Adrese
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adrese>> PostAdrese(Adrese adrese)
        {
          if (_context.Adreses == null)
          {
              return Problem("Entity set 'Seminar2Context.Adreses'  is null.");
          }
            _context.Adreses.Add(adrese);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdrese", new { id = adrese.Id }, adrese);
        }

        // DELETE: api/Adrese/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdrese(int id)
        {
            if (_context.Adreses == null)
            {
                return NotFound();
            }
            var adrese = await _context.Adreses.FindAsync(id);
            if (adrese == null)
            {
                return NotFound();
            }

            _context.Adreses.Remove(adrese);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdreseExists(int id)
        {
            return (_context.Adreses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
