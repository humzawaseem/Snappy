using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Auth
{
    public class User
    {
        public User()
        {
            
        }

        public User(string name, string emailAddress)
        {
            Name = name;
            EmailAddress = emailAddress;
        }

        public string  Name { get; set; }
        public string  EmailAddress { get; set; }
    }
}
