using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_knjiznica.Data;
using E_knjiznica.Models;

namespace E_knjiznica.Controllers
{
    public class JeKreiralController : Controller
    {
        private readonly LibraryContext _context;

        public JeKreiralController(LibraryContext context)
        {
            _context = context;
        }

        // GET: JeKreiral
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.je_Kreiral.Include(j => j.Avtor).Include(j => j.Gradivo);
            return View(await libraryContext.ToListAsync());
        }

        // GET: JeKreiral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var je_kreiral = await _context.je_Kreiral
                .Include(j => j.Avtor)
                .Include(j => j.Gradivo)
                .FirstOrDefaultAsync(m => m.ID_osebe == id);
            if (je_kreiral == null)
            {
                return NotFound();
            }

            return View(je_kreiral);
        }

        // GET: JeKreiral/Create
        public IActionResult Create()
        {
            ViewData["ID_osebe"] = new SelectList(_context.AVTOR, "ID_osebe", "ID_osebe");
            ViewData["Inventarna_stevilka"] = new SelectList(_context.GRADIVO, "Inventarna_stevilka", "Naziv");
            return View();
        }

        // POST: JeKreiral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_osebe,Inventarna_stevilka")] je_kreiral je_kreiral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(je_kreiral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_osebe"] = new SelectList(_context.AVTOR, "ID_osebe", "ID_osebe", je_kreiral.ID_osebe);
            ViewData["Inventarna_stevilka"] = new SelectList(_context.GRADIVO, "Inventarna_stevilka", "Naziv", je_kreiral.Inventarna_stevilka);
            return View(je_kreiral);
        }

        // GET: JeKreiral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var je_kreiral = await _context.je_Kreiral.FindAsync(id);
            if (je_kreiral == null)
            {
                return NotFound();
            }
            ViewData["ID_osebe"] = new SelectList(_context.AVTOR, "ID_osebe", "ID_osebe", je_kreiral.ID_osebe);
            ViewData["Inventarna_stevilka"] = new SelectList(_context.GRADIVO, "Inventarna_stevilka", "Naziv", je_kreiral.Inventarna_stevilka);
            return View(je_kreiral);
        }

        // POST: JeKreiral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_osebe,Inventarna_stevilka")] je_kreiral je_kreiral)
        {
            if (id != je_kreiral.ID_osebe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(je_kreiral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!je_kreiralExists(je_kreiral.ID_osebe))
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
            ViewData["ID_osebe"] = new SelectList(_context.AVTOR, "ID_osebe", "ID_osebe", je_kreiral.ID_osebe);
            ViewData["Inventarna_stevilka"] = new SelectList(_context.GRADIVO, "Inventarna_stevilka", "Naziv", je_kreiral.Inventarna_stevilka);
            return View(je_kreiral);
        }

        // GET: JeKreiral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var je_kreiral = await _context.je_Kreiral
                .Include(j => j.Avtor)
                .Include(j => j.Gradivo)
                .FirstOrDefaultAsync(m => m.ID_osebe == id);
            if (je_kreiral == null)
            {
                return NotFound();
            }

            return View(je_kreiral);
        }

        // POST: JeKreiral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var je_kreiral = await _context.je_Kreiral.FindAsync(id);
            if (je_kreiral != null)
            {
                _context.je_Kreiral.Remove(je_kreiral);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool je_kreiralExists(int id)
        {
            return _context.je_Kreiral.Any(e => e.ID_osebe == id);
        }
    }
}
