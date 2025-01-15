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
    public class PostaController : Controller
    {
        private readonly LibraryContext _context;

        public PostaController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Posta
        public async Task<IActionResult> Index()
        {
            return View(await _context.POSTA.ToListAsync());
        }

        // GET: Posta/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pOSTA = await _context.POSTA
                .FirstOrDefaultAsync(m => m.Postna_stevilka == id);
            if (pOSTA == null)
            {
                return NotFound();
            }

            return View(pOSTA);
        }

        // GET: Posta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Postna_stevilka,Kraj")] POSTA pOSTA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pOSTA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pOSTA);
        }

        // GET: Posta/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pOSTA = await _context.POSTA.FindAsync(id);
            if (pOSTA == null)
            {
                return NotFound();
            }
            return View(pOSTA);
        }

        // POST: Posta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Postna_stevilka,Kraj")] POSTA pOSTA)
        {
            if (id != pOSTA.Postna_stevilka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pOSTA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!POSTAExists(pOSTA.Postna_stevilka))
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
            return View(pOSTA);
        }

        // GET: Posta/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pOSTA = await _context.POSTA
                .FirstOrDefaultAsync(m => m.Postna_stevilka == id);
            if (pOSTA == null)
            {
                return NotFound();
            }

            return View(pOSTA);
        }

        // POST: Posta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var pOSTA = await _context.POSTA.FindAsync(id);
            if (pOSTA != null)
            {
                _context.POSTA.Remove(pOSTA);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool POSTAExists(decimal id)
        {
            return _context.POSTA.Any(e => e.Postna_stevilka == id);
        }
    }
}
