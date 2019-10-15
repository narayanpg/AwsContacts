using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwsContacts.Lib.Models
{
    //here you map your code with db table

    [DynamoDBTable("Contacts")]
    public class ContactDb
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
       public string Email { get; set; }
    }
}
