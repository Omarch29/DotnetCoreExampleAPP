using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solstice.API.models;

namespace Solstice.API.DATA
{
    public class ContactRepository: IContactRepository
    {
        private readonly DataContext _context;
        public ContactRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }


        public async Task<Contact> GetContactRecord(int Id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => 
            c.Id == Id);
        }

        public async Task<Contact> UpdateContactRecord(Contact contact)
        {
            var origin = await _context.Contacts.FirstOrDefaultAsync(c =>
            c.Id == contact.Id);
            origin = contact;
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<IList<Contact>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }
    }
}