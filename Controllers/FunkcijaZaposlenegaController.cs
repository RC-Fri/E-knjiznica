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
    public class FunkcijaZaposlenegaController : Controller
    {
        private readonly LibraryContext _context;

        public FunkcijaZaposlenegaController(LibraryContext context)
        {
            _context = context;
        }

        // GET: FunkcijaZaposlenega
        public async Task<IActionResult> Index()
        {
            return View(await _context.FUNKCIJA_ZAPOSLENEGA.ToListAsync());
        }

        // GET: FunkcijaZaposlenega/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fUNKCIJA_ZAPOSLENEGA = await _context.FUNKCIJA_ZAPOSLENEGA
                .FirstOrDefaultAsync(m => m.ID_funkcija == id);
            if (fUNKCIJA_ZAPOSLENEGA == null)
            {
                return NotFound();
            }

            return View(fUNKCIJA_ZAPOSLENEGA);
        }

        // GET: FunkcijaZaposlenega/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FunkcijaZaposlenega/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_funkcija,Funkcija,Opis_dela")] FUNKCIJA_ZAPOSLENEGA fUNKCIJA_ZAPOSLENEGA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fUNKCIJA_ZAPOSLENEGA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fUNKCIJA_ZAPOSLENEGA);
        }

        // GET: FunkcijaZaposlenega/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fUNKCIJA_ZAPOSLENEGA = await _context.FUNKCIJA_ZAPOSLENEGA.FindAsync(id);
            if (fUNKCIJA_ZAPOSLENEGA == null)
            {
                return NotFound();
            }
            return View(fUNKCIJA_ZAPOSLENEGA);
        }

        // POST: FunkcijaZaposlenega/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_funkcija,Funkcija,Opis_dela")] FUNKCIJA_ZAPOSLENEGA fUNKCIJA_ZAPOSLENEGA)
        {
            if (id != fUNKCIJA_ZAPOSLENEGA.ID_funkcija)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fUNKCIJA_ZAPOSLENEGA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FUNKCIJA_ZAPOSLENEGAExists(fUNKCIJA_ZAPOSLENEGA.ID_funkcija))
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
            return View(fUNKCIJA_ZAPOSLENEGA);
        }

        // GET: FunkcijaZaposlenega/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fUNKCIJA_ZAPOSLENEGA = await _context.FUNKCIJA_ZAPOSLENEGA
                .FirstOrDefaultAsync(m => m.ID_funkcija == id);
            if (fUNKCIJA_ZAPOSLENEGA == null)
            {
                return NotFound();
            }

            return View(fUNKCIJA_ZAPOSLENEGA);
        }

        // POST: FunkcijaZaposlenega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fUNKCIJA_ZAPOSLENEGA = await _context.FUNKCIJA_ZAPOSLENEGA.FindAsync(id);
            if (fUNKCIJA_ZAPOSLENEGA != null)
            {
                _context.FUNKCIJA_ZAPOSLENEGA.Remove(fUNKCIJA_ZAPOSLENEGA);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FUNKCIJA_ZAPOSLENEGAExists(int id)
        {
            return _context.FUNKCIJA_ZAPOSLENEGA.Any(e => e.ID_funkcija == id);
        }
    }
}
