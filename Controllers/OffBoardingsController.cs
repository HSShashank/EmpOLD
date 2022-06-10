using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IBM.Data;
using IBM.Models;

namespace EmployeeDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffBoardingsController : ControllerBase
    {
        private readonly IBMContext _context;

        public OffBoardingsController(IBMContext context)
        {
            _context = context;
        }

        // GET: api/OffBoardings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OffBoarding>>> GetOffBoardings()
        {
          if (_context.OffBoardings == null)
          {
              return NotFound();
          }
            return await _context.OffBoardings.ToListAsync();
        }

        // GET: api/OffBoardings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OffBoarding>> GetOffBoarding(string id)
        {
          if (_context.OffBoardings == null)
          {
              return NotFound();
          }
            var offBoarding = await _context.OffBoardings.FindAsync(id);

            if (offBoarding == null)
            {
                return NotFound();
            }

            return offBoarding;
        }

        // PUT: api/OffBoardings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffBoarding(string id, OffBoarding offBoarding)
        {
            if (id != offBoarding.EmployeeActive)
            {
                return BadRequest();
            }

            _context.Entry(offBoarding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OffBoardingExists(id))
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

        // POST: api/OffBoardings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OffBoarding>> PostOffBoarding(OffBoarding offBoarding)
        {
          if (_context.OffBoardings == null)
          {
              return Problem("Entity set 'IBMContext.OffBoardings'  is null.");
          }
            _context.OffBoardings.Add(offBoarding);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OffBoardingExists(offBoarding.EmployeeActive))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOffBoarding", new { id = offBoarding.EmployeeActive }, offBoarding);
        }

        // DELETE: api/OffBoardings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffBoarding(string id)
        {
            if (_context.OffBoardings == null)
            {
                return NotFound();
            }
            var offBoarding = await _context.OffBoardings.FindAsync(id);
            if (offBoarding == null)
            {
                return NotFound();
            }

            _context.OffBoardings.Remove(offBoarding);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OffBoardingExists(string id)
        {
            return (_context.OffBoardings?.Any(e => e.EmployeeActive == id)).GetValueOrDefault();
        }
    }
}
