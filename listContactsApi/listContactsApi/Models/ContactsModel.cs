using listContactsApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace listContactsApi.Models
{
    
    public class ContactsModel 
    {

        private readonly AppDbContext _context;

        public ContactsModel()
        {

        
        
        }
        public async Task<List<Contact>> getContacts()
        {

           var result=  await _context.contacts.ToListAsync();
            return result;
        }
    }
}
