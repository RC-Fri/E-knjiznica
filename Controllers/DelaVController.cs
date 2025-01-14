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
    public class DelaVController : Controller
    {
        private readonly LibraryContext _context;

        public DelaVController(LibraryContext context)
        {
            _context = context;
        }

        // GET: DelaV
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.dela_v.Include(d => d.Podruznica).Include(d => d.Zaposlen);
            return View(await libraryContext.ToListAsync());
        }

        // GET: DelaV/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dela_v = await _context.dela_v
                .Include(d => d.Podruznica)
                .Include(d => d.Zaposlen)
                .FirstOrDefaultAsync(m => m.ID_zaposlen == id);
            if (dela_v == null)
            {
                return NotFound();
            }

            return View(dela_v);
        }

        // GET: DelaV/Create
        public IActionResult Create()
        {
            ViewData["ID_podruznice"] = new SelectList(_context.PODRUZNICA, "ID_podruznice", "ID_podruznice");
            ViewData["ID_zaposlen"] = new SelectList(_context.ZAPOSLEN, "ID_osebe", "Geslo");
            return View();
        }

        // POST: DelaV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ID_zaposlen,ID_podruznice,Datum_zaposlitve,Datum_odhoda")] dela_v dela_v)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dela_v);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_podruznice"] = new SelectList(_context.PODRUZNICA, "ID_podruznice", "ID_podruznice", dela_v.ID_podruznice);
            ViewData["ID_zaposlen"] = new SelectList(_context.ZAPOSLEN, "ID_osebe", "Geslo", dela_v.ID_zaposlen);
            return View(dela_v);
        }

        // GET: DelaV/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dela_v = await _context.dela_v.FindAsync(id);
            if (dela_v == null)
            {
                return NotFound();
            }
            ViewData["ID_podruznice"] = new SelectList(_context.PODRUZNICA, "ID_podruznice", "ID_podruznice", dela_v.ID_podruznice);
            ViewData["ID_zaposlen"] = new SelectList(_context.ZAPOSLEN, "ID_osebe", "Geslo", dela_v.ID_zaposlen);
            return View(dela_v);
        }

        // POST: DelaV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ID_zaposlen,ID_podruznice,Datum_zaposlitve,Datum_odhoda")] dela_v dela_v)
        {
            if (id != dela_v.ID_zaposlen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dela_v);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dela_vExists(dela_v.ID_zaposlen))
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
            ViewData["ID_podruznice"] = new SelectList(_context.PODRUZNICA, "ID_podruznice", "ID_podruznice", dela_v.ID_podruznice);
            ViewData["ID_zaposlen"] = new SelectList(_context.ZAPOSLEN, "ID_osebe", "Geslo", dela_v.ID_zaposlen);
            return View(dela_v);
        }

        // GET: DelaV/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dela_v = await _context.dela_v
                .Include(d => d.Podruznica)
                .Include(d => d.Zaposlen)
                .FirstOrDefaultAsync(m => m.ID_zaposlen == id);
            if (dela_v == null)
            {
                return NotFound();
            }

            return View(dela_v);
        }

        // POST: DelaV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dela_v = await _context.dela_v.FindAsync(id);
            if (dela_v != null)
            {
                _context.dela_v.Remove(dela_v);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dela_vExists(int id)
        {
            return _context.dela_v.Any(e => e.ID_zaposlen == id);
        }
    }
}
