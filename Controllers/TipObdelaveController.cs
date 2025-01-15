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
    public class TipObdelaveController : Controller
    {
        private readonly LibraryContext _context;

        public TipObdelaveController(LibraryContext context)
        {
            _context = context;
        }

        // GET: TipObdelave
        public async Task<IActionResult> Index()
        {
            return View(await _context.TIP_OBDELAVE.ToListAsync());
        }

        // GET: TipObdelave/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIP_OBDELAVE = await _context.TIP_OBDELAVE
                .FirstOrDefaultAsync(m => m.ID_tip_obdelave == id);
            if (tIP_OBDELAVE == null)
            {
                return NotFound();
            }

            return View(tIP_OBDELAVE);
        }

        // GET: TipObdelave/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipObdelave/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_tip_obdelave,Naziv,Opis")] TIP_OBDELAVE tIP_OBDELAVE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tIP_OBDELAVE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tIP_OBDELAVE);
        }

        // GET: TipObdelave/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIP_OBDELAVE = await _context.TIP_OBDELAVE.FindAsync(id);
            if (tIP_OBDELAVE == null)
            {
                return NotFound();
            }
            return View(tIP_OBDELAVE);
        }

        // POST: TipObdelave/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_tip_obdelave,Naziv,Opis")] TIP_OBDELAVE tIP_OBDELAVE)
        {
            if (id != tIP_OBDELAVE.ID_tip_obdelave)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tIP_OBDELAVE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TIP_OBDELAVEExists(tIP_OBDELAVE.ID_tip_obdelave))
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
            return View(tIP_OBDELAVE);
        }

        // GET: TipObdelave/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tIP_OBDELAVE = await _context.TIP_OBDELAVE
                .FirstOrDefaultAsync(m => m.ID_tip_obdelave == id);
            if (tIP_OBDELAVE == null)
            {
                return NotFound();
            }

            return View(tIP_OBDELAVE);
        }

        // POST: TipObdelave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tIP_OBDELAVE = await _context.TIP_OBDELAVE.FindAsync(id);
            if (tIP_OBDELAVE != null)
            {
                _context.TIP_OBDELAVE.Remove(tIP_OBDELAVE);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TIP_OBDELAVEExists(int id)
        {
            return _context.TIP_OBDELAVE.Any(e => e.ID_tip_obdelave == id);
        }
    }
}
