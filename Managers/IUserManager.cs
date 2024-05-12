using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public interface IUserManager
    {
        Int32 logInValidation(string username, string password);

        Int32 registerNewUser(string email, string username, string password);

        List<string> accountInfo(int id);

        void updateUserAccountInfo(int id, string username, string email, string password);

        void updateUserPersonalInfo(int id, string name, string phone);
    }
}
