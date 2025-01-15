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
    public class OsebaController : Controller
    {
        private readonly LibraryContext _context;

        public OsebaController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Oseba
        public async Task<IActionResult> Index()
        {
            return View(await _context.OSEBA.ToListAsync());
        }

        // GET: Oseba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSEBA = await _context.OSEBA
                .FirstOrDefaultAsync(m => m.ID_osebe == id);
            if (oSEBA == null)
            {
                return NotFound();
            }

            return View(oSEBA);
        }

        // GET: Oseba/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oseba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_osebe,Ime,Priimek")] OSEBA oSEBA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oSEBA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oSEBA);
        }

        // GET: Oseba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSEBA = await _context.OSEBA.FindAsync(id);
            if (oSEBA == null)
            {
                return NotFound();
            }
            return View(oSEBA);
        }

        // POST: Oseba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_osebe,Ime,Priimek")] OSEBA oSEBA)
        {
            if (id != oSEBA.ID_osebe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oSEBA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OSEBAExists(oSEBA.ID_osebe))
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
            return View(oSEBA);
        }

        // GET: Oseba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSEBA = await _context.OSEBA
                .FirstOrDefaultAsync(m => m.ID_osebe == id);
            if (oSEBA == null)
            {
                return NotFound();
            }

            return View(oSEBA);
        }

        // POST: Oseba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oSEBA = await _context.OSEBA.FindAsync(id);
            if (oSEBA != null)
            {
                _context.OSEBA.Remove(oSEBA);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OSEBAExists(int id)
        {
            return _context.OSEBA.Any(e => e.ID_osebe == id);
        }
    }
}
