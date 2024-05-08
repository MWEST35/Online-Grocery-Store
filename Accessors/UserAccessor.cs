using Microsoft.SqlServer.Server;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
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
            SqlConnection conn =
                new SqlConnection("data source=JACK\\SQLEXPRESS;initial catalog=Project_grocery;Integrated security=SSPI;TrustServerCertificate=true");
            return conn;
        }

        string IUserAccessor.validateAccount(string username, string password, SqlConnection conn)
        {
            string results = "";
            string query = "select username, password from Users where username = @username and password = @password";
            using (SqlCommand cmd = new SqlCommand(query))
            {

                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 50);

                cmd.Parameters["@username"].Value = username;
                cmd.Parameters["@password"].Value = password;
                cmd.Connection = conn;


                try
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string line = reader.GetString(0);
                            results = line;
                        }
                    }

                    cmd.Connection.Close();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }

            return results;
        }

        void IUserAccessor.registerUser(string email, string username, string password)
        {
            IUserAccessor userAccessor = new UserAccessor();
            string results;
            results = userAccessor.validateAccount(username, password, userAccessor.createConnection());
            if (!(string.Equals(results, "")))
            {
                // No account with this username and password exists
                SqlParameter userParam = new SqlParameter("@Username", username);
                SqlParameter passParam = new SqlParameter("@Password", password);
                SqlParameter emailParam = new SqlParameter("@Email", email);
                using (SqlCommand command = new SqlCommand(
                    "insert into Users (username, password, email) values ('@Username', '@Password', '@email');"
                    ))
                {
                    command.Parameters.Add(userParam);
                    command.Parameters.Add(passParam);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string line = reader.GetString(0);
                            results = line;
                        }
                    }
                }
            }
        }

        string IUserAccessor.retrieveCart(string userId)
        {
            // TODO: implement a retrieve for the persistent cart based on how cart is tracked by the program.
            return "";
        }
    }
}
