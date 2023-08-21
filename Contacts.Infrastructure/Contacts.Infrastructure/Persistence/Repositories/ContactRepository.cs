using Contacts.Application.Repositories;
using Contacts.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure.Persistence.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _dbContext;

        public ContactRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact> GetContactByIdAsync(Guid id)
        {
            return await _dbContext.Contacts.FindAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _dbContext.Contacts.ToListAsync();
        }

        public async Task AddContactAsync(Contact contact)
        {
            await _dbContext.Contacts.AddAsync(contact);
        }

        public void UpdateContact(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
        }

        public async Task DeleteContactAsync(Guid id)
        {
            var contact = await GetContactByIdAsync(id);
            if (contact != null)
            {
                _dbContext.Contacts.Remove(contact);
            }
        }
    }
}
