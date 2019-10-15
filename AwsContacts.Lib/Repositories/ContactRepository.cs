using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using AwsContacts.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwsContacts.Lib.Repositories
{
    public class ContactRepository: IContactRepository
    {
        //const to store table name
        private const string TableName = "Contacts";

        //this is dbclient for dynamodb
        private readonly IAmazonDynamoDB _dynamoDbClient;

        //dbclient is injected as dependency
        public ContactRepository(IAmazonDynamoDB dynamoDbClient)
        {
            _dynamoDbClient = dynamoDbClient;
        }

        //implement the interface method
        public async Task<ScanResponse> GetAllItems()
        {
            var scanrequest = new ScanRequest(TableName);

            //here you scan all data from the db
            return await _dynamoDbClient.ScanAsync(scanrequest);
        }

        //get contact by querying id and fullname
        public async Task<GetItemResponse> GetContact(int userId, string email)
        {
            var request = new GetItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"UserId", new AttributeValue {N = userId.ToString()}},
                    {"Email", new AttributeValue {S = email}}
                }
            };

            return await _dynamoDbClient.GetItemAsync(request);
        }

        //add contact
        public async Task AddContact(int userId, ContactRequest contactRequest)
        {
            var request = new PutItemRequest
            {
                TableName = TableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"UserId", new AttributeValue {N = userId.ToString()}},
                    {"Email", new AttributeValue {S = contactRequest.Email}},
                    {"Phone", new AttributeValue {S = contactRequest.Phone}},
                    {"FullName", new AttributeValue {S = contactRequest.FullName}}
                }
            };

            await _dynamoDbClient.PutItemAsync(request);
        }

        //update contact
        public async Task UpdateContact(int userId, ContactUpdateRequest updateRequest)
        {
            var request = new UpdateItemRequest
            {
                TableName = TableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    {"UserId", new AttributeValue {N = userId.ToString()}},
                    {"Email", new AttributeValue {S = updateRequest.Email}}
                },
                AttributeUpdates = new Dictionary<string, AttributeValueUpdate>
                {
                     { "Phone", new AttributeValueUpdate
                        {
                            Action = AttributeAction.PUT,
                            Value = new AttributeValue {S = updateRequest.Phone}
                        }
                    },
                      { "FullName", new AttributeValueUpdate
                        {
                            Action = AttributeAction.PUT,
                            Value = new AttributeValue {S = updateRequest.FullName}
                        }
                    },
                }
            };

            await _dynamoDbClient.UpdateItemAsync(request);
        }

        //create new table in dynamodb

        public async Task CreateDynamoDbTable(string dynamoDbTableName)
        {
            var request = new CreateTableRequest
            {
                TableName = dynamoDbTableName,
                AttributeDefinitions = new List<AttributeDefinition>()
                {
                    new AttributeDefinition
                    {
                        AttributeName = "Id",
                        AttributeType = "N"
                    }
                },
                KeySchema = new List<KeySchemaElement>()
                {
                    new KeySchemaElement
                    {
                        AttributeName = "Id",
                        KeyType = "HASH"
                    }
                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 1,
                    WriteCapacityUnits = 1
                }
            };

            await _dynamoDbClient.CreateTableAsync(request);
        }

        //delete table in dynamodb

        public async Task DeleteDynamoDbTable(string dynamoDbTableName)
        {
            var request = new DeleteTableRequest
            {
                TableName = dynamoDbTableName
            };

            await _dynamoDbClient.DeleteTableAsync(request);
        }

    }
}
