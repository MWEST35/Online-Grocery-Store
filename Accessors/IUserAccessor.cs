using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Accessors
{
    public interface IUserAccessor
    {
        Int32 validateAccount(string username, string password, SqlConnection conn);
        Int32 registerUser(string email, string username, string password, SqlConnection conn);
        List<string> getAccountInfo(int id, SqlConnection conn);
        void updateAccountInfo(int id, string username, string email, string password, SqlConnection conn);
        void updatePersonalInfo(int id, string name, string phone, SqlConnection conn);
    }
}
