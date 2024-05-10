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

        bool IUserAccessor.registerUser(string email, string username, string password, SqlConnection conn)
        {
            string query = "select username from Users where username = @username or email = @email";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 100);

                cmd.Parameters["@username"].Value = username;
                cmd.Parameters["@email"].Value = email;
                cmd.Connection = conn;

                try
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cmd.Connection.Close();
                            return false;
                        }
                    }
                    cmd.Connection.Close();

                    string entry_query = "insert into Users (username, email, password, phoneNumber, name) values (@username, @email, @password, '', '')";
                    using (SqlCommand update_cmd = new SqlCommand(entry_query))
                    {
                        update_cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                        update_cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 100);
                        update_cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 50);

                        update_cmd.Parameters["@username"].Value = username;
                        update_cmd.Parameters["@email"].Value = email;
                        update_cmd.Parameters["@password"].Value = password;
                        update_cmd.Connection = conn;

                        update_cmd.Connection.Open();
                        update_cmd.ExecuteNonQuery();
                        update_cmd.Connection.Close();
                    }
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }
            return true;
        }

        string IUserAccessor.retrieveCart(string userId)
        {
            // TODO: implement a retrieve for the persistent cart based on how cart is tracked by the program.
            return "";
        }
    }
}
