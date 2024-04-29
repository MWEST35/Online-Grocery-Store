using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Accessors
{
    internal interface IUserAccessor
    {
        SqlConnection createConnection();
        List<string> validateAccount(string username, string password);

        string retrieveCart(string userId);
        void registerUser(string email, string username, string password);

    }
}
