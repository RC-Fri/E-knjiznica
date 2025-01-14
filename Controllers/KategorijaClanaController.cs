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
    public class KategorijaClanaController : Controller
    {
        private readonly LibraryContext _context;

        public KategorijaClanaController(LibraryContext context)
        {
            _context = context;
        }

        // GET: KategorijaClana
        public async Task<IActionResult> Index()
        {
            return View(await _context.KATEGORIJA_CLANA.ToListAsync());
        }

        // GET: KategorijaClana/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kATEGORIJA_CLANA = await _context.KATEGORIJA_CLANA
                .FirstOrDefaultAsync(m => m.ID_kategorija_clana == id);
            if (kATEGORIJA_CLANA == null)
            {
                return NotFound();
            }

            return View(kATEGORIJA_CLANA);
        }

        // GET: KategorijaClana/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KategorijaClana/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_kategorija_clana,Opis")] KATEGORIJA_CLANA kATEGORIJA_CLANA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kATEGORIJA_CLANA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kATEGORIJA_CLANA);
        }

        // GET: KategorijaClana/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kATEGORIJA_CLANA = await _context.KATEGORIJA_CLANA.FindAsync(id);
            if (kATEGORIJA_CLANA == null)
            {
                return NotFound();
            }
            return View(kATEGORIJA_CLANA);
        }

        // POST: KategorijaClana/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_kategorija_clana,Opis")] KATEGORIJA_CLANA kATEGORIJA_CLANA)
        {
            if (id != kATEGORIJA_CLANA.ID_kategorija_clana)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kATEGORIJA_CLANA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KATEGORIJA_CLANAExists(kATEGORIJA_CLANA.ID_kategorija_clana))
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
            return View(kATEGORIJA_CLANA);
        }

        // GET: KategorijaClana/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kATEGORIJA_CLANA = await _context.KATEGORIJA_CLANA
                .FirstOrDefaultAsync(m => m.ID_kategorija_clana == id);
            if (kATEGORIJA_CLANA == null)
            {
                return NotFound();
            }

            return View(kATEGORIJA_CLANA);
        }

        // POST: KategorijaClana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kATEGORIJA_CLANA = await _context.KATEGORIJA_CLANA.FindAsync(id);
            if (kATEGORIJA_CLANA != null)
            {
                _context.KATEGORIJA_CLANA.Remove(kATEGORIJA_CLANA);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KATEGORIJA_CLANAExists(int id)
        {
            return _context.KATEGORIJA_CLANA.Any(e => e.ID_kategorija_clana == id);
        }
    }
}
