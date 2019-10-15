using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwsContacts.Services
{
    public interface ICreateService
    {
        Task CreateDynamoDbTable(string dynamoDbTable);
        Task DeleteDynamoDbTable(string dynamoDbTableName);
    }
}
