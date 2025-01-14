using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_knjiznica.Data;

namespace E_knjiznica.Controllers
{
    public class ZaposlenController : Controller
    {
        private readonly LibraryContext _context;

        public ZaposlenController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Zaposlen
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.ZAPOSLEN.Include(z => z.Funkcija);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Zaposlen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zAPOSLEN = await _context.ZAPOSLEN
                .Include(z => z.Funkcija)
                .FirstOrDefaultAsync(m => m.ID_osebe == id);
            if (zAPOSLEN == null)
            {
                return NotFound();
            }

            return View(zAPOSLEN);
        }

        // GET: Zaposlen/Create
        public IActionResult Create()
        {
            ViewData["ID_funkcija"] = new SelectList(_context.FUNKCIJA_ZAPOSLENEGA, "ID_funkcija", "Funkcija");
            return View();
        }

        // POST: Zaposlen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_osebe,ID_funkcija,Placa,Uporabnisko_ime,Geslo")] ZAPOSLEN zAPOSLEN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zAPOSLEN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_funkcija"] = new SelectList(_context.FUNKCIJA_ZAPOSLENEGA, "ID_funkcija", "Funkcija", zAPOSLEN.ID_funkcija);
            return View(zAPOSLEN);
        }

        // GET: Zaposlen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zAPOSLEN = await _context.ZAPOSLEN.FindAsync(id);
            if (zAPOSLEN == null)
            {
                return NotFound();
            }
            ViewData["ID_funkcija"] = new SelectList(_context.FUNKCIJA_ZAPOSLENEGA, "ID_funkcija", "Funkcija", zAPOSLEN.ID_funkcija);
            return View(zAPOSLEN);
        }

        // POST: Zaposlen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_osebe,ID_funkcija,Placa,Uporabnisko_ime,Geslo")] ZAPOSLEN zAPOSLEN)
        {
            if (id != zAPOSLEN.ID_osebe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zAPOSLEN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZAPOSLENExists(zAPOSLEN.ID_osebe))
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
            ViewData["ID_funkcija"] = new SelectList(_context.FUNKCIJA_ZAPOSLENEGA, "ID_funkcija", "Funkcija", zAPOSLEN.ID_funkcija);
            return View(zAPOSLEN);
        }

        // GET: Zaposlen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zAPOSLEN = await _context.ZAPOSLEN
                .Include(z => z.Funkcija)
                .FirstOrDefaultAsync(m => m.ID_osebe == id);
            if (zAPOSLEN == null)
            {
                return NotFound();
            }

            return View(zAPOSLEN);
        }

        // POST: Zaposlen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zAPOSLEN = await _context.ZAPOSLEN.FindAsync(id);
            if (zAPOSLEN != null)
            {
                _context.ZAPOSLEN.Remove(zAPOSLEN);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZAPOSLENExists(int id)
        {
            return _context.ZAPOSLEN.Any(e => e.ID_osebe == id);
        }
    }
}
