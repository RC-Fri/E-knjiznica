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
    public class ObdelavaGradivController : Controller
    {
        private readonly LibraryContext _context;

        public ObdelavaGradivController(LibraryContext context)
        {
            _context = context;
        }

        // GET: ObdelavaGradiv
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.OBDELAVA_GRADIV.Include(o => o.Clan).Include(o => o.Gradivo).Include(o => o.TipObdelave).Include(o => o.Zaposlen);
            return View(await libraryContext.ToListAsync());
        }

        // GET: ObdelavaGradiv/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oBDELAVA_GRADIV = await _context.OBDELAVA_GRADIV
                .Include(o => o.Clan)
                .Include(o => o.Gradivo)
                .Include(o => o.TipObdelave)
                .Include(o => o.Zaposlen)
                .FirstOrDefaultAsync(m => m.ID_obdelave == id);
            if (oBDELAVA_GRADIV == null)
            {
                return NotFound();
            }

            return View(oBDELAVA_GRADIV);
        }

        // GET: ObdelavaGradiv/Create
        public IActionResult Create()
        {
            ViewData["ID_clan"] = new SelectList(_context.CLAN, "ID_osebe", "ID_osebe");
            ViewData["Inventarna_stevilka"] = new SelectList(_context.GRADIVO, "Inventarna_stevilka", "Naziv");
            ViewData["ID_tip_obdelave"] = new SelectList(_context.TIP_OBDELAVE, "ID_tip_obdelave", "Naziv");
            ViewData["ID_zaposlen"] = new SelectList(_context.ZAPOSLEN, "ID_osebe", "Geslo");
            return View();
        }

        // POST: ObdelavaGradiv/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_obdelave,ID_tip_obdelave,Inventarna_stevilka,ID_zaposlen,ID_clan,Datum_obdelave,Datum_od,Datum_do,Obracun")] OBDELAVA_GRADIV oBDELAVA_GRADIV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oBDELAVA_GRADIV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_clan"] = new SelectList(_context.CLAN, "ID_osebe", "ID_osebe", oBDELAVA_GRADIV.ID_clan);
            ViewData["Inventarna_stevilka"] = new SelectList(_context.GRADIVO, "Inventarna_stevilka", "Naziv", oBDELAVA_GRADIV.Inventarna_stevilka);
            ViewData["ID_tip_obdelave"] = new SelectList(_context.TIP_OBDELAVE, "ID_tip_obdelave", "Naziv", oBDELAVA_GRADIV.ID_tip_obdelave);
            ViewData["ID_zaposlen"] = new SelectList(_context.ZAPOSLEN, "ID_osebe", "Geslo", oBDELAVA_GRADIV.ID_zaposlen);
            return View(oBDELAVA_GRADIV);
        }

        // GET: ObdelavaGradiv/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oBDELAVA_GRADIV = await _context.OBDELAVA_GRADIV.FindAsync(id);
            if (oBDELAVA_GRADIV == null)
            {
                return NotFound();
            }
            ViewData["ID_clan"] = new SelectList(_context.CLAN, "ID_osebe", "ID_osebe", oBDELAVA_GRADIV.ID_clan);
            ViewData["Inventarna_stevilka"] = new SelectList(_context.GRADIVO, "Inventarna_stevilka", "Naziv", oBDELAVA_GRADIV.Inventarna_stevilka);
            ViewData["ID_tip_obdelave"] = new SelectList(_context.TIP_OBDELAVE, "ID_tip_obdelave", "Naziv", oBDELAVA_GRADIV.ID_tip_obdelave);
            ViewData["ID_zaposlen"] = new SelectList(_context.ZAPOSLEN, "ID_osebe", "Geslo", oBDELAVA_GRADIV.ID_zaposlen);
            return View(oBDELAVA_GRADIV);
        }

        // POST: ObdelavaGradiv/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_obdelave,ID_tip_obdelave,Inventarna_stevilka,ID_zaposlen,ID_clan,Datum_obdelave,Datum_od,Datum_do,Obracun")] OBDELAVA_GRADIV oBDELAVA_GRADIV)
        {
            if (id != oBDELAVA_GRADIV.ID_obdelave)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oBDELAVA_GRADIV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OBDELAVA_GRADIVExists(oBDELAVA_GRADIV.ID_obdelave))
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
            ViewData["ID_clan"] = new SelectList(_context.CLAN, "ID_osebe", "ID_osebe", oBDELAVA_GRADIV.ID_clan);
            ViewData["Inventarna_stevilka"] = new SelectList(_context.GRADIVO, "Inventarna_stevilka", "Naziv", oBDELAVA_GRADIV.Inventarna_stevilka);
            ViewData["ID_tip_obdelave"] = new SelectList(_context.TIP_OBDELAVE, "ID_tip_obdelave", "Naziv", oBDELAVA_GRADIV.ID_tip_obdelave);
            ViewData["ID_zaposlen"] = new SelectList(_context.ZAPOSLEN, "ID_osebe", "Geslo", oBDELAVA_GRADIV.ID_zaposlen);
            return View(oBDELAVA_GRADIV);
        }

        // GET: ObdelavaGradiv/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oBDELAVA_GRADIV = await _context.OBDELAVA_GRADIV
                .Include(o => o.Clan)
                .Include(o => o.Gradivo)
                .Include(o => o.TipObdelave)
                .Include(o => o.Zaposlen)
                .FirstOrDefaultAsync(m => m.ID_obdelave == id);
            if (oBDELAVA_GRADIV == null)
            {
                return NotFound();
            }

            return View(oBDELAVA_GRADIV);
        }

        // POST: ObdelavaGradiv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oBDELAVA_GRADIV = await _context.OBDELAVA_GRADIV.FindAsync(id);
            if (oBDELAVA_GRADIV != null)
            {
                _context.OBDELAVA_GRADIV.Remove(oBDELAVA_GRADIV);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OBDELAVA_GRADIVExists(int id)
        {
            return _context.OBDELAVA_GRADIV.Any(e => e.ID_obdelave == id);
        }
    }
}
