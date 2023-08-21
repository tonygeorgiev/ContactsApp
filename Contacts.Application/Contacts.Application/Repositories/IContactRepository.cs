using Contacts.Domain.Models;

namespace Contacts.Application.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> GetContactByIdAsync(Guid id);
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task AddContactAsync(Contact contact);
        void UpdateContact(Contact contact);
        Task DeleteContactAsync(Guid id);
    }
}
