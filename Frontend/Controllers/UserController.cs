using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;


namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        SqlConnection conn =
            new SqlConnection("data source = Kalelius\\SQLEXPRESS; initial catalog = grocery; TrustServerCertificate = True; user id = sa; password = sixpeasinapod");

        [HttpGet("{username}/{password}")]
        public bool Get(string username, string password)
        {

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
                           if (reader.GetString(0) == username && reader.GetString(1) == password)
                           {
                                return true;
                           }
                       }
                    }

                    cmd.Connection.Close();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }

            return false;
        }
        
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public List<string> Get(int id)
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

            query = "select name, phoneNumber from Customers where user_id = @id";
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
        
        [HttpPost]
        public bool Post(User user)
        {
            SqlConnection conn =
                new SqlConnection("data source = Kalelius\\SQLEXPRESS; initial catalog = grocery; TrustServerCertificate = True; user id = sa; password = sixpeasinapod");

            string query = "select username from Users where username = @username or email = @email";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 100);

                cmd.Parameters["@username"].Value = user.Name;
                cmd.Parameters["@email"].Value = user.Email;
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

                    string entry_query = "insert into Users (username, email, password) values (@username, @email, @password)";
                    using (SqlCommand update_cmd = new SqlCommand(entry_query))
                    {
                        update_cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 50);
                        update_cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar, 100);
                        update_cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 50);

                        update_cmd.Parameters["@username"].Value = user.Name;
                        update_cmd.Parameters["@email"].Value = user.Email;
                        update_cmd.Parameters["@password"].Value = user.Password;
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

        
        // PUT api/<ValuesController>/5
        [HttpPut("{id}/{username}/{email}/{password}")]
        public void Put(int id, string username, string email, string password)
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

        [HttpPut("{id}/{name}/{phone}")]
        public void Put(int id, string name, string phone)
        {
            string query = "update Customers set name = @name, phoneNumber = @phone where user_id = @id";
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

        /**
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}