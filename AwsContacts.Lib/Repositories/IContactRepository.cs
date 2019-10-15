using Amazon.DynamoDBv2.Model;
using AwsContacts.Contracts;
using AwsContacts.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AwsContacts.Lib.Repositories
{
    public interface IContactRepository
    {
        Task<ScanResponse> GetAllItems();
        Task<GetItemResponse> GetContact(int id, string email);
        Task AddContact(int userId, ContactRequest contactRequest);
        Task UpdateContact(int userId, ContactUpdateRequest updateRequest);
        Task CreateDynamoDbTable(string dynamoDbTableName);
        Task DeleteDynamoDbTable(string dynamoDbTableName); 
    }
}
