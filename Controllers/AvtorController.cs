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
    public class AvtorController : Controller
    {
        private readonly LibraryContext _context;

        public AvtorController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Avtor
        public async Task<IActionResult> Index()
        {
            return View(await _context.AVTOR.ToListAsync());
        }

        // GET: Avtor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aVTOR = await _context.AVTOR
                .FirstOrDefaultAsync(m => m.ID_osebe == id);
            if (aVTOR == null)
            {
                return NotFound();
            }

            return View(aVTOR);
        }

        // GET: Avtor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Avtor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_osebe,Pseudonim,Datum_rojstva,Datum_smrti")] AVTOR aVTOR)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aVTOR);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aVTOR);
        }

        // GET: Avtor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aVTOR = await _context.AVTOR.FindAsync(id);
            if (aVTOR == null)
            {
                return NotFound();
            }
            return View(aVTOR);
        }

        // POST: Avtor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_osebe,Pseudonim,Datum_rojstva,Datum_smrti")] AVTOR aVTOR)
        {
            if (id != aVTOR.ID_osebe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aVTOR);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AVTORExists(aVTOR.ID_osebe))
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
            return View(aVTOR);
        }

        // GET: Avtor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aVTOR = await _context.AVTOR
                .FirstOrDefaultAsync(m => m.ID_osebe == id);
            if (aVTOR == null)
            {
                return NotFound();
            }

            return View(aVTOR);
        }

        // POST: Avtor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aVTOR = await _context.AVTOR.FindAsync(id);
            if (aVTOR != null)
            {
                _context.AVTOR.Remove(aVTOR);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AVTORExists(int id)
        {
            return _context.AVTOR.Any(e => e.ID_osebe == id);
        }
    }
}
