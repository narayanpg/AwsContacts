using System;
using System.Collections.Generic;
using System.Text;

namespace AwsContacts.Contracts
{
    public class ContactRequest
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }

    }
}
