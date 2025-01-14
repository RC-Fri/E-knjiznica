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
    public class TipGradivaController : Controller
    {
        private readonly LibraryContext _context;

        public TipGradivaController(LibraryContext context)
        {
            _context = context;
        }

        // GET: TipGradiva
        public async Task<IActionResult> Index()
        {
            return View(await _context.TIP_GRADIVA.ToListAsync());
        }

        // GET: TipGradiva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIP_GRADIVA = await _context.TIP_GRADIVA
                .FirstOrDefaultAsync(m => m.ID_tip_gradiva == id);
            if (tIP_GRADIVA == null)
            {
                return NotFound();
            }

            return View(tIP_GRADIVA);
        }

        // GET: TipGradiva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipGradiva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_tip_gradiva,Naziv,Opis")] TIP_GRADIVA tIP_GRADIVA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tIP_GRADIVA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tIP_GRADIVA);
        }

        // GET: TipGradiva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIP_GRADIVA = await _context.TIP_GRADIVA.FindAsync(id);
            if (tIP_GRADIVA == null)
            {
                return NotFound();
            }
            return View(tIP_GRADIVA);
        }

        // POST: TipGradiva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_tip_gradiva,Naziv,Opis")] TIP_GRADIVA tIP_GRADIVA)
        {
            if (id != tIP_GRADIVA.ID_tip_gradiva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tIP_GRADIVA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TIP_GRADIVAExists(tIP_GRADIVA.ID_tip_gradiva))
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
            return View(tIP_GRADIVA);
        }

        // GET: TipGradiva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIP_GRADIVA = await _context.TIP_GRADIVA
                .FirstOrDefaultAsync(m => m.ID_tip_gradiva == id);
            if (tIP_GRADIVA == null)
            {
                return NotFound();
            }

            return View(tIP_GRADIVA);
        }

        // POST: TipGradiva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tIP_GRADIVA = await _context.TIP_GRADIVA.FindAsync(id);
            if (tIP_GRADIVA != null)
            {
                _context.TIP_GRADIVA.Remove(tIP_GRADIVA);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TIP_GRADIVAExists(int id)
        {
            return _context.TIP_GRADIVA.Any(e => e.ID_tip_gradiva == id);
        }
    }
}
