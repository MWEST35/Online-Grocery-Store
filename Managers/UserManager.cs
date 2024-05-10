using Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public class UserManager : IUserManager
    {
        IUserAccessor userAccessor = new UserAccessor();
        IConnectionAccessor connectionAccessor = new ConnectionAccessor();
        string IUserManager.logInValidation(string username, string password)
        {

            string result = userAccessor.validateAccount(username, password, connectionAccessor.createConnection());
            return result;
        }

        bool IUserManager.registerNewUser(string email, string username, string password)
        {
            return userAccessor.registerUser(email, username, password, connectionAccessor.createConnection());

        }
    }
}
