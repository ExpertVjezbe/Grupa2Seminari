using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Seminar2ZeljkaMaletic.Database;

namespace Seminar2ZeljkaMaletic.Controllers
{
    public class GradovisController : Controller
    {
        private readonly Seminar2Context _context;

        public GradovisController(Seminar2Context context)
        {
            _context = context;
        }

        // GET: Gradovis
        public async Task<IActionResult> Index()
        {
            var seminar2Context = _context.Gradovis.Include(g => g.IdDrzaveNavigation);
            return View(await seminar2Context.ToListAsync());
        }

        // GET: Gradovis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gradovis == null)
            {
                return NotFound();
            }

            var gradovi = await _context.Gradovis
                .Include(g => g.IdDrzaveNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gradovi == null)
            {
                return NotFound();
            }

            return View(gradovi);
        }

        // GET: Gradovis/Create
        public IActionResult Create()
        {
            ViewData["IdDrzave"] = new SelectList(_context.Drzaves, "Id", "Id");
            return View();
        }

        // POST: Gradovis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,PostanskiBroj,IdDrzave")] Gradovi gradovi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradovi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDrzave"] = new SelectList(_context.Drzaves, "Id", "Id", gradovi.IdDrzave);
            return View(gradovi);
        }

        // GET: Gradovis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gradovis == null)
            {
                return NotFound();
            }

            var gradovi = await _context.Gradovis.FindAsync(id);
            if (gradovi == null)
            {
                return NotFound();
            }
            ViewData["IdDrzave"] = new SelectList(_context.Drzaves, "Id", "Id", gradovi.IdDrzave);
            return View(gradovi);
        }

        // POST: Gradovis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,PostanskiBroj,IdDrzave")] Gradovi gradovi)
        {
            if (id != gradovi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradovi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradoviExists(gradovi.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDrzave"] = new SelectList(_context.Drzaves, "Id", "Id", gradovi.IdDrzave);
            return View(gradovi);
        }

        // GET: Gradovis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gradovis == null)
            {
                return NotFound();
            }

            var gradovi = await _context.Gradovis
                .Include(g => g.IdDrzaveNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gradovi == null)
            {
                return NotFound();
            }

            return View(gradovi);
        }

        // POST: Gradovis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gradovis == null)
            {
                return Problem("Entity set 'Seminar2Context.Gradovis'  is null.");
            }
            var gradovi = await _context.Gradovis.FindAsync(id);
            if (gradovi != null)
            {
                _context.Gradovis.Remove(gradovi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradoviExists(int id)
        {
          return (_context.Gradovis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
