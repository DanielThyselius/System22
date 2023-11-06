using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthenticator
{
    public interface IMailService
    {
        public bool SendPassword(string email, string password);
        public bool SendNotification(string email, string message);


    }
}
