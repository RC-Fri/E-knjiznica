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
    public class SubsidiariesController : Controller
    {
        private readonly LibraryContext _context;

        public SubsidiariesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Subsidiaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subsidiaries.ToListAsync());
        }

        // GET: Subsidiaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsidiary = await _context.Subsidiaries
                .FirstOrDefaultAsync(m => m.SubsidiaryID == id);
            if (subsidiary == null)
            {
                return NotFound();
            }

            return View(subsidiary);
        }

        // GET: Subsidiaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subsidiaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubsidiaryID,Name,Location")] Subsidiary subsidiary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subsidiary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subsidiary);
        }

        // GET: Subsidiaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsidiary = await _context.Subsidiaries.FindAsync(id);
            if (subsidiary == null)
            {
                return NotFound();
            }
            return View(subsidiary);
        }

        // POST: Subsidiaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubsidiaryID,Name,Location")] Subsidiary subsidiary)
        {
            if (id != subsidiary.SubsidiaryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subsidiary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubsidiaryExists(subsidiary.SubsidiaryID))
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
            return View(subsidiary);
        }

        // GET: Subsidiaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subsidiary = await _context.Subsidiaries
                .FirstOrDefaultAsync(m => m.SubsidiaryID == id);
            if (subsidiary == null)
            {
                return NotFound();
            }

            return View(subsidiary);
        }

        // POST: Subsidiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subsidiary = await _context.Subsidiaries.FindAsync(id);
            if (subsidiary != null)
            {
                _context.Subsidiaries.Remove(subsidiary);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubsidiaryExists(int id)
        {
            return _context.Subsidiaries.Any(e => e.SubsidiaryID == id);
        }
    }
}
