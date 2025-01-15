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
    public class ZalozbaController : Controller
    {
        private readonly LibraryContext _context;

        public ZalozbaController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Zalozba
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZALOZBA.ToListAsync());
        }

        // GET: Zalozba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zALOZBA = await _context.ZALOZBA
                .FirstOrDefaultAsync(m => m.ID_zalozba == id);
            if (zALOZBA == null)
            {
                return NotFound();
            }

            return View(zALOZBA);
        }

        // GET: Zalozba/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zalozba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_zalozba,Naziv,Opis")] ZALOZBA zALOZBA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zALOZBA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zALOZBA);
        }

        // GET: Zalozba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zALOZBA = await _context.ZALOZBA.FindAsync(id);
            if (zALOZBA == null)
            {
                return NotFound();
            }
            return View(zALOZBA);
        }

        // POST: Zalozba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_zalozba,Naziv,Opis")] ZALOZBA zALOZBA)
        {
            if (id != zALOZBA.ID_zalozba)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zALOZBA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZALOZBAExists(zALOZBA.ID_zalozba))
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
            return View(zALOZBA);
        }

        // GET: Zalozba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zALOZBA = await _context.ZALOZBA
                .FirstOrDefaultAsync(m => m.ID_zalozba == id);
            if (zALOZBA == null)
            {
                return NotFound();
            }

            return View(zALOZBA);
        }

        // POST: Zalozba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zALOZBA = await _context.ZALOZBA.FindAsync(id);
            if (zALOZBA != null)
            {
                _context.ZALOZBA.Remove(zALOZBA);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZALOZBAExists(int id)
        {
            return _context.ZALOZBA.Any(e => e.ID_zalozba == id);
        }
    }
}
