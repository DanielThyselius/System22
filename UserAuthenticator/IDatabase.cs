using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthenticator
{
    public interface IDatabase
    {
        bool AddUser(User user);

        User GetUser(string usernname);
    }
}
