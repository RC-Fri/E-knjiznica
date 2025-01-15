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
    public class TipPodruzniceController : Controller
    {
        private readonly LibraryContext _context;

        public TipPodruzniceController(LibraryContext context)
        {
            _context = context;
        }

        // GET: TipPodruznice
        public async Task<IActionResult> Index()
        {
            return View(await _context.TIP_PODRUZNICE.ToListAsync());
        }

        // GET: TipPodruznice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIP_PODRUZNICE = await _context.TIP_PODRUZNICE
                .FirstOrDefaultAsync(m => m.ID_tip_podruznice == id);
            if (tIP_PODRUZNICE == null)
            {
                return NotFound();
            }

            return View(tIP_PODRUZNICE);
        }

        // GET: TipPodruznice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipPodruznice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_tip_podruznice,Naziv,Opis")] TIP_PODRUZNICE tIP_PODRUZNICE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tIP_PODRUZNICE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tIP_PODRUZNICE);
        }

        // GET: TipPodruznice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIP_PODRUZNICE = await _context.TIP_PODRUZNICE.FindAsync(id);
            if (tIP_PODRUZNICE == null)
            {
                return NotFound();
            }
            return View(tIP_PODRUZNICE);
        }

        // POST: TipPodruznice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_tip_podruznice,Naziv,Opis")] TIP_PODRUZNICE tIP_PODRUZNICE)
        {
            if (id != tIP_PODRUZNICE.ID_tip_podruznice)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tIP_PODRUZNICE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TIP_PODRUZNICEExists(tIP_PODRUZNICE.ID_tip_podruznice))
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
            return View(tIP_PODRUZNICE);
        }

        // GET: TipPodruznice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIP_PODRUZNICE = await _context.TIP_PODRUZNICE
                .FirstOrDefaultAsync(m => m.ID_tip_podruznice == id);
            if (tIP_PODRUZNICE == null)
            {
                return NotFound();
            }

            return View(tIP_PODRUZNICE);
        }

        // POST: TipPodruznice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tIP_PODRUZNICE = await _context.TIP_PODRUZNICE.FindAsync(id);
            if (tIP_PODRUZNICE != null)
            {
                _context.TIP_PODRUZNICE.Remove(tIP_PODRUZNICE);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TIP_PODRUZNICEExists(int id)
        {
            return _context.TIP_PODRUZNICE.Any(e => e.ID_tip_podruznice == id);
        }
    }
}
