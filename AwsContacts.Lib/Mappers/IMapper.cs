using Amazon.DynamoDBv2.Model;
using AwsContacts.Contracts;
using AwsContacts.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwsContacts.Lib.Mappers
{
    public interface IMapper
    {
        IEnumerable<ContactsResponse> ToContactContract(ScanResponse response);
        ContactsResponse ToContactContract(GetItemResponse response);


    }
}
