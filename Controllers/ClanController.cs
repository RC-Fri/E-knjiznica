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
    public class ClanController : Controller
    {
        private readonly LibraryContext _context;

        public ClanController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Clan
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.CLAN.Include(c => c.KategorijaClana).Include(c => c.Oseba);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Clan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cLAN = await _context.CLAN
                .Include(c => c.KategorijaClana)
                .Include(c => c.Oseba)
                .FirstOrDefaultAsync(m => m.ID_osebe == id);
            if (cLAN == null)
            {
                return NotFound();
            }

            return View(cLAN);
        }

        // GET: Clan/Create
        public IActionResult Create()
        {
            ViewData["ID_kategorija_clana"] = new SelectList(_context.KATEGORIJA_CLANA, "ID_kategorija_clana", "Opis");
            ViewData["ID_osebe"] = new SelectList(_context.OSEBA, "ID_osebe", "Ime");
            return View();
        }

        // POST: Clan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_osebe,ID_kategorija_clana,GDPR,E_posta,Informiranje_preko_e_poste,Konec_clanstva")] CLAN cLAN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cLAN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_kategorija_clana"] = new SelectList(_context.KATEGORIJA_CLANA, "ID_kategorija_clana", "Opis", cLAN.ID_kategorija_clana);
            ViewData["ID_osebe"] = new SelectList(_context.OSEBA, "ID_osebe", "Ime", cLAN.ID_osebe);
            return View(cLAN);
        }

        // GET: Clan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cLAN = await _context.CLAN.FindAsync(id);
            if (cLAN == null)
            {
                return NotFound();
            }
            ViewData["ID_kategorija_clana"] = new SelectList(_context.KATEGORIJA_CLANA, "ID_kategorija_clana", "Opis", cLAN.ID_kategorija_clana);
            ViewData["ID_osebe"] = new SelectList(_context.OSEBA, "ID_osebe", "Ime", cLAN.ID_osebe);
            return View(cLAN);
        }

        // POST: Clan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_osebe,ID_kategorija_clana,GDPR,E_posta,Informiranje_preko_e_poste,Konec_clanstva")] CLAN cLAN)
        {
            if (id != cLAN.ID_osebe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cLAN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CLANExists(cLAN.ID_osebe))
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
            ViewData["ID_kategorija_clana"] = new SelectList(_context.KATEGORIJA_CLANA, "ID_kategorija_clana", "Opis", cLAN.ID_kategorija_clana);
            ViewData["ID_osebe"] = new SelectList(_context.OSEBA, "ID_osebe", "Ime", cLAN.ID_osebe);
            return View(cLAN);
        }

        // GET: Clan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cLAN = await _context.CLAN
                .Include(c => c.KategorijaClana)
                .Include(c => c.Oseba)
                .FirstOrDefaultAsync(m => m.ID_osebe == id);
            if (cLAN == null)
            {
                return NotFound();
            }

            return View(cLAN);
        }

        // POST: Clan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cLAN = await _context.CLAN.FindAsync(id);
            if (cLAN != null)
            {
                _context.CLAN.Remove(cLAN);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CLANExists(int id)
        {
            return _context.CLAN.Any(e => e.ID_osebe == id);
        }
    }
}
