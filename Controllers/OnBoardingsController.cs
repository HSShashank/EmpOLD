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
    public class OnBoardingsController : ControllerBase
    {
        private readonly IBMContext _context;

        public OnBoardingsController(IBMContext context)
        {
            _context = context;
        }

        // GET: api/OnBoardings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OnBoarding>>> GetOnBoardings()
        {
          if (_context.OnBoardings == null)
          {
              return NotFound();
          }
            return await _context.OnBoardings.ToListAsync();
        }

        // GET: api/OnBoardings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OnBoarding>> GetOnBoarding(string id)
        {
          if (_context.OnBoardings == null)
          {
              return NotFound();
          }
            var onBoarding = await _context.OnBoardings.FindAsync(id);

            if (onBoarding == null)
            {
                return NotFound();
            }

            return onBoarding;
        }

        // PUT: api/OnBoardings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnBoarding(string id, OnBoarding onBoarding)
        {
            if (id != onBoarding.CoOrdinatorName)
            {
                return BadRequest();
            }

            _context.Entry(onBoarding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnBoardingExists(id))
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

        // POST: api/OnBoardings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OnBoarding>> PostOnBoarding(OnBoarding onBoarding)
        {
          if (_context.OnBoardings == null)
          {
              return Problem("Entity set 'IBMContext.OnBoardings'  is null.");
          }
            _context.OnBoardings.Add(onBoarding);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OnBoardingExists(onBoarding.CoOrdinatorName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOnBoarding", new { id = onBoarding.CoOrdinatorName }, onBoarding);
        }

        // DELETE: api/OnBoardings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnBoarding(string id)
        {
            if (_context.OnBoardings == null)
            {
                return NotFound();
            }
            var onBoarding = await _context.OnBoardings.FindAsync(id);
            if (onBoarding == null)
            {
                return NotFound();
            }

            _context.OnBoardings.Remove(onBoarding);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OnBoardingExists(string id)
        {
            return (_context.OnBoardings?.Any(e => e.CoOrdinatorName == id)).GetValueOrDefault();
        }
    }
}
