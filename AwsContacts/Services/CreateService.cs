using AwsContacts.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwsContacts.Services
{
    public class CreateService: ICreateService
    {
        private readonly IContactRepository _contactRepository;

        public CreateService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task CreateDynamoDbTable (string dynamoDbTable)
        {
            await _contactRepository.CreateDynamoDbTable(dynamoDbTable);
        }

        public async Task DeleteDynamoDbTable(string dynamoDbTableName)
        {
            await _contactRepository.DeleteDynamoDbTable(dynamoDbTableName);
        }
    }
}
