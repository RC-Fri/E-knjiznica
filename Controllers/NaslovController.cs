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
    public class NaslovController : Controller
    {
        private readonly LibraryContext _context;

        public NaslovController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Naslov
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.NASLOV.Include(n => n.Clan).Include(n => n.Posta);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Naslov/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nASLOV = await _context.NASLOV
                .Include(n => n.Clan)
                .Include(n => n.Posta)
                .FirstOrDefaultAsync(m => m.Postna_stevilka == id);
            if (nASLOV == null)
            {
                return NotFound();
            }

            return View(nASLOV);
        }

        // GET: Naslov/Create
        public IActionResult Create()
        {
            ViewData["ID_osebe"] = new SelectList(_context.CLAN, "ID_osebe", "ID_osebe");
            ViewData["Postna_stevilka"] = new SelectList(_context.POSTA, "Postna_stevilka", "Postna_stevilka");
            return View();
        }

        // POST: Naslov/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Postna_stevilka,Ulica,Hisna_stevilka,ID_osebe")] NASLOV nASLOV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nASLOV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_osebe"] = new SelectList(_context.CLAN, "ID_osebe", "ID_osebe", nASLOV.ID_osebe);
            ViewData["Postna_stevilka"] = new SelectList(_context.POSTA, "Postna_stevilka", "Postna_stevilka", nASLOV.Postna_stevilka);
            return View(nASLOV);
        }

        // GET: Naslov/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nASLOV = await _context.NASLOV.FindAsync(id);
            if (nASLOV == null)
            {
                return NotFound();
            }
            ViewData["ID_osebe"] = new SelectList(_context.CLAN, "ID_osebe", "ID_osebe", nASLOV.ID_osebe);
            ViewData["Postna_stevilka"] = new SelectList(_context.POSTA, "Postna_stevilka", "Postna_stevilka", nASLOV.Postna_stevilka);
            return View(nASLOV);
        }

        // POST: Naslov/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Postna_stevilka,Ulica,Hisna_stevilka,ID_osebe")] NASLOV nASLOV)
        {
            if (id != nASLOV.Postna_stevilka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nASLOV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NASLOVExists(nASLOV.Postna_stevilka))
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
            ViewData["ID_osebe"] = new SelectList(_context.CLAN, "ID_osebe", "ID_osebe", nASLOV.ID_osebe);
            ViewData["Postna_stevilka"] = new SelectList(_context.POSTA, "Postna_stevilka", "Postna_stevilka", nASLOV.Postna_stevilka);
            return View(nASLOV);
        }

        // GET: Naslov/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nASLOV = await _context.NASLOV
                .Include(n => n.Clan)
                .Include(n => n.Posta)
                .FirstOrDefaultAsync(m => m.Postna_stevilka == id);
            if (nASLOV == null)
            {
                return NotFound();
            }

            return View(nASLOV);
        }

        // POST: Naslov/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nASLOV = await _context.NASLOV.FindAsync(id);
            if (nASLOV != null)
            {
                _context.NASLOV.Remove(nASLOV);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NASLOVExists(string id)
        {
            return _context.NASLOV.Any(e => e.Postna_stevilka == id);
        }
    }
}
