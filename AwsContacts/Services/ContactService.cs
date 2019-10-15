using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwsContacts.Contracts;
using AwsContacts.Lib.Mappers;
using AwsContacts.Lib.Repositories;

namespace AwsContacts.Services
{
    public class ContactService : IContactService
    {
        //you bring these classes so that you can inject as dependency
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        //here you inject those as dependency through constructor
        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactsResponse>> GetAllItemsFromDatabase()
        {
            var response = await _contactRepository.GetAllItems();
            return _mapper.ToContactContract(response);
        }

        //get contact by id and email
        public async Task<ContactsResponse> GetContact(int userId, string email)
        {
            var response = await _contactRepository.GetContact(userId, email);

            return _mapper.ToContactContract(response);
        }

        //add contact
        public async Task AddContact(int userId, ContactRequest contactRequest)
        {
            await _contactRepository.AddContact(userId, contactRequest);
        }

        //contact contact

        public async Task UpdateContact(int userId, ContactUpdateRequest request)
        {
            await _contactRepository.UpdateContact(userId, request);
        }

    }
}
