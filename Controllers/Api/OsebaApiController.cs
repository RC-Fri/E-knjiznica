using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_knjiznica.Data;
using E_knjiznica.Models;

namespace E_knjiznica.Controllers_Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsebaApiController : ControllerBase
    {
        private readonly LibraryContext _context;

        public OsebaApiController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/OsebaApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OSEBA>>> GetOSEBA()
        {
            return await _context.OSEBA.ToListAsync();
        }

        // GET: api/OsebaApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OSEBA>> GetOSEBA(int id)
        {
            var oSEBA = await _context.OSEBA.FindAsync(id);

            if (oSEBA == null)
            {
                return NotFound();
            }

            return oSEBA;
        }

        
        [HttpGet("login/username={username}password={password}")]
        public async Task<ActionResult<OSEBA>> GetOSEBA(string username, string password)
        {
            var oSEBA = await _context.OSEBA
                .FirstOrDefaultAsync(o => o.Uporabnisko_ime == username && o.Geslo == password);

            if (oSEBA == null)
            {
                return NotFound();
            }

            return oSEBA;
        }


        // PUT: api/OsebaApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOSEBA(int id, OSEBA oSEBA)
        {
            if (id != oSEBA.ID_osebe)
            {
                return BadRequest();
            }

            _context.Entry(oSEBA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OSEBAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OsebaApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OSEBA>> PostOSEBA(OSEBA oSEBA)
        {
            _context.OSEBA.Add(oSEBA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOSEBA", new { id = oSEBA.ID_osebe }, oSEBA);
        }

        // DELETE: api/OsebaApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOSEBA(int id)
        {
            var oSEBA = await _context.OSEBA.FindAsync(id);
            if (oSEBA == null)
            {
                return NotFound();
            }

            _context.OSEBA.Remove(oSEBA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OSEBAExists(int id)
        {
            return _context.OSEBA.Any(e => e.ID_osebe == id);
        }
    }
}
