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

        Int32 IUserAccessor.validateAccount(string username, string password, SqlConnection conn)
        {
            Int32 result = 0;
            string query = "select user_id from Users where username = @username and password = @password";
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
                            result = reader.GetInt32(0);
                        }
                    }

                    cmd.Connection.Close();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }

            return result;
        }

        Int32 IUserAccessor.registerUser(string email, string username, string password, SqlConnection conn)
        {

            Int32 userId = 0;
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
                            return userId;
                        }
                    }
                    cmd.Connection.Close();
                    string entry_query = "insert into Users (username, email, password, phoneNumber, name) values (@username, @email, @password, \'\', \'\'); select scope_identity()";
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
                        userId = Convert.ToInt32(update_cmd.ExecuteScalar());
                        update_cmd.Connection.Close();
                    }
                    string cart_query = "insert into Cart (user_id) values (@userId);";
                    using (SqlCommand cart_cmd = new SqlCommand(cart_query))
                    {
                        cart_cmd.Parameters.Add("@userId", System.Data.SqlDbType.Int);
                        cart_cmd.Parameters["@userId"].Value = userId;
                        cart_cmd.Connection = conn;

                        cart_cmd.Connection.Open();
                        cart_cmd.ExecuteNonQuery();
                        cart_cmd.Connection.Close();
                    }
                    string shipping_query = "insert into ShippingAddress (address, state, city, zip, user_id) values (\'\', \'\', \'\', \'\', @userId)";
                    using (SqlCommand shipping_cmd = new SqlCommand(shipping_query))
                    {
                        shipping_cmd.Parameters.Add("@userId", System.Data.SqlDbType.Int);
                        shipping_cmd.Parameters["@userId"].Value = userId;
                        shipping_cmd.Connection = conn;

                        shipping_cmd.Connection.Open();
                        shipping_cmd.ExecuteNonQuery();
                        shipping_cmd.Connection.Close();
                    }
                    string card_query = "insert into Card (Name, cardNumber, cvv, expDate, user_id) values (\'\', \'\', 0, \'\', @userId)";
                    using (SqlCommand card_cmd = new SqlCommand(card_query))
                    {
                        card_cmd.Parameters.Add("@userId", System.Data.SqlDbType.Int);
                        card_cmd.Parameters["@userId"].Value = userId;
                        card_cmd.Connection = conn;

                        card_cmd.Connection.Open();
                        card_cmd.ExecuteNonQuery();
                        card_cmd.Connection.Close();
                    }
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }
            return userId;
        }

        List<string> IUserAccessor.getAccountInfo(int id, SqlConnection conn)
        {
            string username = "";
            string email = "";
            string password = "";
            string name = "";
            string phone = "";
            List<string> account_personal = new List<string>();

            string query = "select username, email, password from Users where user_id = @id";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);

                cmd.Parameters["@id"].Value = id;
                cmd.Connection = conn;

                try
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            username = reader.GetString(0);
                            email = reader.GetString(1);
                            password = reader.GetString(2);
                        }
                    }

                    cmd.Connection.Close();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }

            query = "select name, phoneNumber from Users where user_id = @id";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);

                cmd.Parameters["@id"].Value = id;
                cmd.Connection = conn;

                try
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            name = reader.GetString(0);
                            phone = reader.GetString(1);
                        }
                    }
                    cmd.Connection.Close();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }

            account_personal.Add(username);
            account_personal.Add(email);
            account_personal.Add(password);
            account_personal.Add(name);
            account_personal.Add(phone);
            return account_personal;
        }

        void IUserAccessor.updateAccountInfo(int id, string username, string email, string password, SqlConnection conn)
        {
            string query = "update Users set username = @username, email = @email, password = @password where user_id = @id";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);

                cmd.Parameters["@username"].Value = username;
                cmd.Parameters["@email"].Value = email;
                cmd.Parameters["@password"].Value = password;
                cmd.Parameters["@id"].Value = id;
                cmd.Connection = conn;

                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }

            return;
        }

        void IUserAccessor.updatePersonalInfo(int id, string name, string phone, SqlConnection conn)
        {
            string query = "update Users set name = @name, phoneNumber = @phone where user_id = @id";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@phone", System.Data.SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);

                cmd.Parameters["@name"].Value = name;
                cmd.Parameters["@phone"].Value = phone;
                cmd.Parameters["@id"].Value = id;
                cmd.Connection = conn;

                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }

            return;
        }
    }
}
