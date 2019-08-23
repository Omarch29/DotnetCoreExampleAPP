using System.Collections.Generic;
using System.Threading.Tasks;
using Solstice.API.models;

namespace Solstice.API.DATA
{
    public interface IContactRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<Contact> GetContactRecord(int Id);

        Task<Contact> UpdateContactRecord(Contact contact);

        Task<IList<Contact>> GetAllContacts();
    }
}