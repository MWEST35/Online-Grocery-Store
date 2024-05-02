using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        //data source=Kalelius\SQLEXPRESS;initial catalog=grocery;user id=sa;password=sixpeasinapod
        
        [HttpGet("{username}/{password}")]
        public bool  Get(string username, string password)
        {
            SqlConnection conn =
                new SqlConnection("data source = Kalelius\\SQLEXPRESS; initial catalog = grocery; TrustServerCertificate = True; user id = sa; password = sixpeasinapod");

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

        /**
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public bool Post([FromBody] string value)
        {
            return true;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}