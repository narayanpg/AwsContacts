using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwsContacts.Contracts;
using AwsContacts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AwsContacts.Controllers
{
    [Route("contacts")]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactsResponse>> GetAllContactsFromDatabase()
        {
            var results = await _contactService.GetAllItemsFromDatabase();
            return results;
        }

        [HttpGet]
        [Route("{userId}/{email}")]
        public async Task<ContactsResponse> GetContact(int userId, string email)
        {
            var result = await _contactService.GetContact(userId, email);

            return result;
        }
        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> AddContact(int userId, [FromBody] ContactRequest contactRequest)
        {
            await _contactService.AddContact(userId, contactRequest);

            return Ok();
        }

        [HttpPatch]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateContact(int userId, [FromBody] ContactUpdateRequest request)
        {
            await _contactService.UpdateContact(userId, request);

            return Ok();
        }


    }
}