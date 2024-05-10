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
        string IUserManager.logInValidation(string username, string password)
        {

            string result = userAccessor.validateAccount(username, password, userAccessor.createConnection());
            return result;
        }

        bool IUserManager.registerNewUser(string email, string username, string password)
        {
            return userAccessor.registerUser(email, username, password, userAccessor.createConnection());

        }
    }
}
