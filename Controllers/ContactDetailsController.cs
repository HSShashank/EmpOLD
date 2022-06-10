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
    public class ContactDetailsController : ControllerBase
    {
        private readonly IBMContext _context;

        public ContactDetailsController(IBMContext context)
        {
            _context = context;
        }

        // GET: api/ContactDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDetail>>> GetContactDetails()
        {
            if (_context.ContactDetails == null)
            {
                return NotFound();
            }
            return await _context.ContactDetails.ToListAsync();
        }

        // GET: api/ContactDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDetail>> GetContactDetail(int id)
        {
            if (_context.ContactDetails == null)
            {
                return NotFound();
            }
            var contactDetail = await _context.ContactDetails.FindAsync(id);

            if (contactDetail == null)
            {
                return NotFound();
            }

            return contactDetail;
        }

        // PUT: api/ContactDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactDetail(int id, ContactDetail contactDetail)
        {
            if (id != contactDetail.PhoneNumber)
            {
                return BadRequest();
            }

            _context.Entry(contactDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactDetailExists(id))
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

        // POST: api/ContactDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactDetail>> PostContactDetail(ContactDetail contactDetail)
        {
            if (_context.ContactDetails == null)
            {
                return Problem("Entity set 'IBMContext.ContactDetails'  is null.");
            }
            _context.ContactDetails.Add(contactDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContactDetailExists(contactDetail.PhoneNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContactDetail", new { id = contactDetail.PhoneNumber }, contactDetail);
        }

        // DELETE: api/ContactDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactDetail(int id)
        {
            if (_context.ContactDetails == null)
            {
                return NotFound();
            }
            var contactDetail = await _context.ContactDetails.FindAsync(id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            _context.ContactDetails.Remove(contactDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactDetailExists(int id)
        {
            return (_context.ContactDetails?.Any(e => e.PhoneNumber == id)).GetValueOrDefault();
        }
    }
}