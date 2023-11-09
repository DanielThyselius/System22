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

        public User Register(string username, string email)
        {
            ValidateUsername(username);

            var user = new User();
            user.Name = username;
            user.Email = email;
            user.Password = "password";


            // This should probably live in _database.AddUser()
            var userInDb = _database.GetUser(username);
            if (userInDb == null)
            {
                throw new ArgumentException("already exists", "username");
            }

            _database.AddUser(user);

            _mailService.SendPassword(user.Email, user.Password);
            return user;
        }

        private static void ValidateUsername(string username)
        {
            if (username.Contains("@"))
            {
                throw new ArgumentException("No @!");
            }
        }

  
        public bool Login(string username, string password)
        {
            var user = new User();
            try
            {
                user = _database.GetUser(username);
            }
            catch (Exception)
            {
                // log and return fail
                return false;
            }

            return (user.Password == password);
            
        }

        public void Logout(User user)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Only for testing!
        /// </summary>
        /// <param name="s"></param>
        public void TESTValidateUsername(string s) => ValidateUsername(s);


    }
}
