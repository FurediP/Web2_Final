using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using listContactsApi.Data;
using listContactsApi.Models;

namespace listContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeContactsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TypeContactsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TypeContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeContact>>> GetTypeContacts()
        {
            return await _context.typecontacts.ToListAsync();
        }

        // GET: api/TypeContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeContact>> GetTypeContact(int id)
        {
            var typeContact = await _context.typecontacts.FindAsync(id);

            if (typeContact == null)
            {
                return NotFound();
            }

            return typeContact;
        }

        // PUT: api/TypeContacts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeContact(int id, TypeContact typeContact)
        {
            if (id != typeContact.typecontactid)
            {
                return BadRequest();
            }

            _context.Entry(typeContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeContactExists(id))
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

        // POST: api/TypeContacts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeContact>> PostTypeContact(TypeContact typeContact)
        {
            _context.typecontacts.Add(typeContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeContact", new { id = typeContact.typecontactid }, typeContact);
        }

        // DELETE: api/TypeContacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeContact>> DeleteTypeContact(int id)
        {
            var typeContact = await _context.typecontacts.FindAsync(id);
            if (typeContact == null)
            {
                return NotFound();
            }

            _context.typecontacts.Remove(typeContact);
            await _context.SaveChangesAsync();

            return typeContact;
        }

        private bool TypeContactExists(int id)
        {
            return _context.typecontacts.Any(e => e.typecontactid == id);
        }
    }
}
