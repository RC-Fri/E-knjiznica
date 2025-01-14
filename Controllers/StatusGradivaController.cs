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
    public class StatusGradivaController : Controller
    {
        private readonly LibraryContext _context;

        public StatusGradivaController(LibraryContext context)
        {
            _context = context;
        }

        // GET: StatusGradiva
        public async Task<IActionResult> Index()
        {
            return View(await _context.STATUS_GRADIVA.ToListAsync());
        }

        // GET: StatusGradiva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sTATUS_GRADIVA = await _context.STATUS_GRADIVA
                .FirstOrDefaultAsync(m => m.ID_status == id);
            if (sTATUS_GRADIVA == null)
            {
                return NotFound();
            }

            return View(sTATUS_GRADIVA);
        }

        // GET: StatusGradiva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusGradiva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_status,Naziv,Opis")] STATUS_GRADIVA sTATUS_GRADIVA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sTATUS_GRADIVA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sTATUS_GRADIVA);
        }

        // GET: StatusGradiva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sTATUS_GRADIVA = await _context.STATUS_GRADIVA.FindAsync(id);
            if (sTATUS_GRADIVA == null)
            {
                return NotFound();
            }
            return View(sTATUS_GRADIVA);
        }

        // POST: StatusGradiva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_status,Naziv,Opis")] STATUS_GRADIVA sTATUS_GRADIVA)
        {
            if (id != sTATUS_GRADIVA.ID_status)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sTATUS_GRADIVA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!STATUS_GRADIVAExists(sTATUS_GRADIVA.ID_status))
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
            return View(sTATUS_GRADIVA);
        }

        // GET: StatusGradiva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sTATUS_GRADIVA = await _context.STATUS_GRADIVA
                .FirstOrDefaultAsync(m => m.ID_status == id);
            if (sTATUS_GRADIVA == null)
            {
                return NotFound();
            }

            return View(sTATUS_GRADIVA);
        }

        // POST: StatusGradiva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sTATUS_GRADIVA = await _context.STATUS_GRADIVA.FindAsync(id);
            if (sTATUS_GRADIVA != null)
            {
                _context.STATUS_GRADIVA.Remove(sTATUS_GRADIVA);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool STATUS_GRADIVAExists(int id)
        {
            return _context.STATUS_GRADIVA.Any(e => e.ID_status == id);
        }
    }
}
