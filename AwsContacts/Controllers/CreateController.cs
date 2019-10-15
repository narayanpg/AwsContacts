using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwsContacts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AwsContacts.Controllers
{
    [Route("create")]
    public class CreateController : Controller
    {
        private readonly ICreateService _createService;

        public CreateController(ICreateService createService)
        {
            _createService = createService;
        }

        [HttpPost]
        [Route("createtable/{dynamodbtablename}")]
        public async Task<IActionResult> CreateDynamoDbTable(string dynamodbtablename)
        {
            await _createService.CreateDynamoDbTable(dynamodbtablename);
            return Ok();
        }
        [HttpPost]
        [Route("deletetable/{dynamodbtablename}")]
        public async Task<IActionResult> DeleteDynamoDbTable(string dynamodbtablename)
        {
            await _createService.DeleteDynamoDbTable(dynamodbtablename);
            return Ok();
        }

    }
}