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
        Int32 IUserManager.logInValidation(string username, string password)
        {

            Int32 result = userAccessor.validateAccount(username, password, connectionAccessor.createConnection());
            return result;
        }

        Int32 IUserManager.registerNewUser(string email, string username, string password)
        {
            return userAccessor.registerUser(email, username, password, connectionAccessor.createConnection());

        }
    }
}
