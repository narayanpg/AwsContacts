using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.DynamoDBv2.Model;
using AwsContacts.Contracts;
using AwsContacts.Lib.Models;

namespace AwsContacts.Lib.Mappers
{
    public class Mapper : IMapper
    {
        //this is for get by scan
        public IEnumerable<ContactsResponse> ToContactContract(ScanResponse response)
        {
            return response.Items.Select(ToContactContract);
        }

        //this is for get by query

        public IEnumerable<ContactsResponse> ToContactContract(QueryResponse response)
        {
            return response.Items.Select(ToContactContract);
        }

        //this maps for both above
        private ContactsResponse ToContactContract(Dictionary<string, AttributeValue> item)
        {
            return new ContactsResponse
            {
                FullName = item["FullName"].S,
                Phone = item["Phone"].S,
                Email = item["Email"].S
            };
        }

        public ContactsResponse ToContactContract(GetItemResponse response)
        {
            return new ContactsResponse
            {
                Email = response.Item["Email"].S,
                Phone = response.Item["Phone"].S,
                FullName = response.Item["FullName"].S,
            };
        }
        
    }
}
