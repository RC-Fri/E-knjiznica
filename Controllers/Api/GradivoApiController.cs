using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_knjiznica.Data;
using E_knjiznica.Models;
using web.Filters;

namespace E_knjiznica.Controllers_Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradivoApiController : ControllerBase
    {
        private readonly LibraryContext _context;

        public GradivoApiController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/GradivoApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GRADIVO>>> GetGRADIVO()
        {
            return await _context.GRADIVO.ToListAsync();
        }

        // GET: api/GradivoApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GRADIVO>> GetGRADIVO(int id)
        {
            var gRADIVO = await _context.GRADIVO.FindAsync(id);

            if (gRADIVO == null)
            {
                return NotFound();
            }

            return gRADIVO;
        }

        // PUT: api/GradivoApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGRADIVO(int id, GRADIVO gRADIVO)
        {
            if (id != gRADIVO.Inventarna_stevilka)
            {
                return BadRequest();
            }

            _context.Entry(gRADIVO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GRADIVOExists(id))
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

        // POST: api/GradivoApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GRADIVO>> PostGRADIVO(GRADIVO gRADIVO)
        {
            _context.GRADIVO.Add(gRADIVO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGRADIVO", new { id = gRADIVO.Inventarna_stevilka }, gRADIVO);
        }

        // DELETE: api/GradivoApi/5
        [HttpDelete("{id}")]
        [ApiKeyAuth]
        public async Task<IActionResult> DeleteGRADIVO(int id)
        {
            var gRADIVO = await _context.GRADIVO.FindAsync(id);
            if (gRADIVO == null)
            {
                return NotFound();
            }

            _context.GRADIVO.Remove(gRADIVO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GRADIVOExists(int id)
        {
            return _context.GRADIVO.Any(e => e.Inventarna_stevilka == id);
        }
    }
}
