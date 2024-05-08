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
        string IUserManager.logInValidation(string username, string password)
        {
            IUserAccessor userAccessor = new UserAccessor;
            string result = userAccessor.validateAccount(username, password, userAccessor.createConnection());
            return result;
        }
    }
}
