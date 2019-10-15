using AwsContacts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwsContacts.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactsResponse>> GetAllItemsFromDatabase();
        Task<ContactsResponse> GetContact(int id, string email);
        Task AddContact(int userId, ContactRequest contactRequest);
        Task UpdateContact(int userId, ContactUpdateRequest request);
    }
}
