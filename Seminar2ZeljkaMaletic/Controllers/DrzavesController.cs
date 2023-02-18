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
    public class DrzavesController : Controller
    {
        private readonly Seminar2Context _context;

        public DrzavesController(Seminar2Context context)
        {
            _context = context;
        }

        // GET: Drzaves
        public async Task<IActionResult> Index()
        {
              return _context.Drzaves != null ? 
                          View(await _context.Drzaves.ToListAsync()) :
                          Problem("Entity set 'Seminar2Context.Drzaves'  is null.");
        }

        // GET: Drzaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drzaves == null)
            {
                return NotFound();
            }

            var drzave = await _context.Drzaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drzave == null)
            {
                return NotFound();
            }

            return View(drzave);
        }

        // GET: Drzaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drzaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Kratica,Opis")] Drzave drzave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drzave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drzave);
        }

        // GET: Drzaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drzaves == null)
            {
                return NotFound();
            }

            var drzave = await _context.Drzaves.FindAsync(id);
            if (drzave == null)
            {
                return NotFound();
            }
            return View(drzave);
        }

        // POST: Drzaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Kratica,Opis")] Drzave drzave)
        {
            if (id != drzave.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drzave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrzaveExists(drzave.Id))
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
            return View(drzave);
        }

        // GET: Drzaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drzaves == null)
            {
                return NotFound();
            }

            var drzave = await _context.Drzaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drzave == null)
            {
                return NotFound();
            }

            return View(drzave);
        }

        // POST: Drzaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drzaves == null)
            {
                return Problem("Entity set 'Seminar2Context.Drzaves'  is null.");
            }
            var drzave = await _context.Drzaves.FindAsync(id);
            if (drzave != null)
            {
                _context.Drzaves.Remove(drzave);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrzaveExists(int id)
        {
          return (_context.Drzaves?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
