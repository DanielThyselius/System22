using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthenticator
{

    /*
    *    User Class: Create a User class to represent a user with properties like UserId,
    *    Username, Password, and Email.
    */
    public class User
    {
        public Guid UserId { get; set; } 
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
