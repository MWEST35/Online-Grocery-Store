using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Accessors
{
    public class UserAccessor : IUserAccessor
    {
        SqlConnection IUserAccessor.createConnection()
        {
            // TODO: Fill in connection string
            string connString = @"temp";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }

        List<string> IUserAccessor.validateAccount(string username, string password)
        {
            SqlParameter userParam = new SqlParameter("@Username", username);
            SqlParameter passParam = new SqlParameter("@Password", password);
            List<string> results = new List<string>();
            using (SqlCommand command = new SqlCommand(
                "SELECT UserId FROM Account WHERE Username = @Username AND Password = @Password"
                ))
            {
                command.Parameters.Add(userParam);
                command.Parameters.Add(passParam);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string line = reader.GetString(0);
                        results.Add(line);
                    }
                }
            }
            return results;
        }
    }
}
