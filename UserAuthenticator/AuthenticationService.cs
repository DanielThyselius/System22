using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthenticator
{
    /*
     * 
        Authentication Service: Implement an AuthenticationService class that provides methods
        for user registration, login, and password change. These methods should interact with
        external services for email notifications and SMS notifications.
    */

    public class AuthenticationService
    {
        private readonly IMailService _mailService;
        private readonly IDatabase _database;

        public AuthenticationService(IMailService mailService, IDatabase database)
        {
            this._mailService = mailService;
            this._database = database;
        }

        public User Register(string name, string email)
        {
            
            throw new NotImplementedException();
        }

        public bool Login(User user)
        {
            throw new NotImplementedException();
        }

        public void Logout(User user)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(User user)
        {
            throw new NotImplementedException();
        }
    }
}
