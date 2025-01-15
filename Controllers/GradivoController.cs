using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_knjiznica.Data;
using E_knjiznica.Models;
using Microsoft.AspNetCore.Authorization;

namespace E_knjiznica.Controllers
{
    public class GradivoController : Controller
    {
        private readonly LibraryContext _context;

        public GradivoController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Gradivo
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.GRADIVO.Include(g => g.Podruznica).Include(g => g.StatusGradiva).Include(g => g.TipGradiva).Include(g => g.Zalozba);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Gradivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gRADIVO = await _context.GRADIVO
                .Include(g => g.Podruznica)
                .Include(g => g.StatusGradiva)
                .Include(g => g.TipGradiva)
                .Include(g => g.Zalozba)
                .FirstOrDefaultAsync(m => m.Inventarna_stevilka == id);
            if (gRADIVO == null)
            {
                return NotFound();
            }

            return View(gRADIVO);
        }

        // GET: Gradivo/Create
        public IActionResult Create()
        {
            ViewData["ID_podruznice"] = new SelectList(_context.PODRUZNICA, "ID_podruznice", "ID_podruznice");
            ViewData["ID_status"] = new SelectList(_context.STATUS_GRADIVA, "ID_status", "Naziv");
            ViewData["ID_tip_gradiva"] = new SelectList(_context.TIP_GRADIVA, "ID_tip_gradiva", "Naziv");
            ViewData["ID_zalozba"] = new SelectList(_context.ZALOZBA, "ID_zalozba", "Naziv");
            return View();
        }

        // POST: Gradivo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Inventarna_stevilka,ID_tip_gradiva,ID_zalozba,ID_status,ID_podruznice,Naziv,Datum_izdaje")] GRADIVO gRADIVO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gRADIVO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID_podruznice"] = new SelectList(_context.PODRUZNICA, "ID_podruznice", "ID_podruznice", gRADIVO.ID_podruznice);
            ViewData["ID_status"] = new SelectList(_context.STATUS_GRADIVA, "ID_status", "Naziv", gRADIVO.ID_status);
            ViewData["ID_tip_gradiva"] = new SelectList(_context.TIP_GRADIVA, "ID_tip_gradiva", "Naziv", gRADIVO.ID_tip_gradiva);
            ViewData["ID_zalozba"] = new SelectList(_context.ZALOZBA, "ID_zalozba", "Naziv", gRADIVO.ID_zalozba);
            return View(gRADIVO);
        }

        // GET: Gradivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gRADIVO = await _context.GRADIVO.FindAsync(id);
            if (gRADIVO == null)
            {
                return NotFound();
            }
            ViewData["ID_podruznice"] = new SelectList(_context.PODRUZNICA, "ID_podruznice", "ID_podruznice", gRADIVO.ID_podruznice);
            ViewData["ID_status"] = new SelectList(_context.STATUS_GRADIVA, "ID_status", "Naziv", gRADIVO.ID_status);
            ViewData["ID_tip_gradiva"] = new SelectList(_context.TIP_GRADIVA, "ID_tip_gradiva", "Naziv", gRADIVO.ID_tip_gradiva);
            ViewData["ID_zalozba"] = new SelectList(_context.ZALOZBA, "ID_zalozba", "Naziv", gRADIVO.ID_zalozba);
            return View(gRADIVO);
        }

        // POST: Gradivo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Inventarna_stevilka,ID_tip_gradiva,ID_zalozba,ID_status,ID_podruznice,Naziv,Datum_izdaje")] GRADIVO gRADIVO)
        {
            if (id != gRADIVO.Inventarna_stevilka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gRADIVO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GRADIVOExists(gRADIVO.Inventarna_stevilka))
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
            ViewData["ID_podruznice"] = new SelectList(_context.PODRUZNICA, "ID_podruznice", "ID_podruznice", gRADIVO.ID_podruznice);
            ViewData["ID_status"] = new SelectList(_context.STATUS_GRADIVA, "ID_status", "Naziv", gRADIVO.ID_status);
            ViewData["ID_tip_gradiva"] = new SelectList(_context.TIP_GRADIVA, "ID_tip_gradiva", "Naziv", gRADIVO.ID_tip_gradiva);
            ViewData["ID_zalozba"] = new SelectList(_context.ZALOZBA, "ID_zalozba", "Naziv", gRADIVO.ID_zalozba);
            return View(gRADIVO);
        }

        // GET: Gradivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gRADIVO = await _context.GRADIVO
                .Include(g => g.Podruznica)
                .Include(g => g.StatusGradiva)
                .Include(g => g.TipGradiva)
                .Include(g => g.Zalozba)
                .FirstOrDefaultAsync(m => m.Inventarna_stevilka == id);
            if (gRADIVO == null)
            {
                return NotFound();
            }

            return View(gRADIVO);
        }

        // POST: Gradivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gRADIVO = await _context.GRADIVO.FindAsync(id);
            if (gRADIVO != null)
            {
                _context.GRADIVO.Remove(gRADIVO);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GRADIVOExists(int id)
        {
            return _context.GRADIVO.Any(e => e.Inventarna_stevilka == id);
        }
    }
}
