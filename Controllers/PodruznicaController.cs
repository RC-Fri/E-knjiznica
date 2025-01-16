using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_knjiznica.Data;
using E_knjiznica.Models;
using Microsoft.AspNetCore.Authorization;

namespace E_knjiznica.Controllers
{
    public class PodruznicaController : Controller
    {
        private readonly LibraryContext _context;

        public PodruznicaController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Podruznica
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.PODRUZNICA.Include(p => p.TipPodruznice);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Podruznica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pODRUZNICA = await _context.PODRUZNICA
                .Include(p => p.TipPodruznice)
                .FirstOrDefaultAsync(m => m.ID_podruznice == id);
            if (pODRUZNICA == null)
            {
                return NotFound();
            }

            return View(pODRUZNICA);
        }

        // GET: Podruznica/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ID_tip_podruznice"] = new SelectList(_context.TIP_PODRUZNICE, "ID_tip_podruznice", "Naziv");
            return View();
        }

        // POST: Podruznica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID_podruznice,ID_tip_podruznice,Posta")] PODRUZNICA pODRUZNICA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pODRUZNICA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_tip_podruznice"] = new SelectList(_context.TIP_PODRUZNICE, "ID_tip_podruznice", "Naziv", pODRUZNICA.ID_tip_podruznice);
            return View(pODRUZNICA);
        }

        // GET: Podruznica/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pODRUZNICA = await _context.PODRUZNICA.FindAsync(id);
            if (pODRUZNICA == null)
            {
                return NotFound();
            }
            ViewData["ID_tip_podruznice"] = new SelectList(_context.TIP_PODRUZNICE, "ID_tip_podruznice", "Naziv", pODRUZNICA.ID_tip_podruznice);
            return View(pODRUZNICA);
        }

        // POST: Podruznica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_podruznice,ID_tip_podruznice,Posta")] PODRUZNICA pODRUZNICA)
        {
            if (id != pODRUZNICA.ID_podruznice)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pODRUZNICA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PODRUZNICAExists(pODRUZNICA.ID_podruznice))
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
            ViewData["ID_tip_podruznice"] = new SelectList(_context.TIP_PODRUZNICE, "ID_tip_podruznice", "Naziv", pODRUZNICA.ID_tip_podruznice);
            return View(pODRUZNICA);
        }

        // GET: Podruznica/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pODRUZNICA = await _context.PODRUZNICA
                .Include(p => p.TipPodruznice)
                .FirstOrDefaultAsync(m => m.ID_podruznice == id);
            if (pODRUZNICA == null)
            {
                return NotFound();
            }

            return View(pODRUZNICA);
        }

        // POST: Podruznica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pODRUZNICA = await _context.PODRUZNICA.FindAsync(id);
            if (pODRUZNICA != null)
            {
                _context.PODRUZNICA.Remove(pODRUZNICA);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PODRUZNICAExists(int id)
        {
            return _context.PODRUZNICA.Any(e => e.ID_podruznice == id);
        }
    }
}
