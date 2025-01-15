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
    public class ObdelavaGradivoApiController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ObdelavaGradivoApiController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/ObdelavaGradivoApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OBDELAVA_GRADIV>>> GetOBDELAVA_GRADIV()
        {
            return await _context.OBDELAVA_GRADIV.ToListAsync();
        }

        // GET: api/ObdelavaGradivoApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OBDELAVA_GRADIV>> GetOBDELAVA_GRADIV(int id)
        {
            var oBDELAVA_GRADIV = await _context.OBDELAVA_GRADIV.FindAsync(id);

            if (oBDELAVA_GRADIV == null)
            {
                return NotFound();
            }

            return oBDELAVA_GRADIV;
        }

        // PUT: api/ObdelavaGradivoApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOBDELAVA_GRADIV(int id, OBDELAVA_GRADIV oBDELAVA_GRADIV)
        {
            if (id != oBDELAVA_GRADIV.ID_obdelave)
            {
                return BadRequest();
            }

            _context.Entry(oBDELAVA_GRADIV).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OBDELAVA_GRADIVExists(id))
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

        // POST: api/ObdelavaGradivoApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OBDELAVA_GRADIV>> PostOBDELAVA_GRADIV(OBDELAVA_GRADIV oBDELAVA_GRADIV)
        {
            _context.OBDELAVA_GRADIV.Add(oBDELAVA_GRADIV);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOBDELAVA_GRADIV", new { id = oBDELAVA_GRADIV.ID_obdelave }, oBDELAVA_GRADIV);
        }

        // DELETE: api/ObdelavaGradivoApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOBDELAVA_GRADIV(int id)
        {
            var oBDELAVA_GRADIV = await _context.OBDELAVA_GRADIV.FindAsync(id);
            if (oBDELAVA_GRADIV == null)
            {
                return NotFound();
            }

            _context.OBDELAVA_GRADIV.Remove(oBDELAVA_GRADIV);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OBDELAVA_GRADIVExists(int id)
        {
            return _context.OBDELAVA_GRADIV.Any(e => e.ID_obdelave == id);
        }
    }
}
