using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingController : ControllerBase
    {
        SqlConnection conn =
            new SqlConnection("data source = Kalelius\\SQLEXPRESS; initial catalog = grocery; TrustServerCertificate = True; user id = sa; password = sixpeasinapod");

        [HttpGet("{id}")]
        public List<string> Get(int id)
        {
            string address = "";
            string state = "";
            string city = "";
            string zip = "";
            List<string> shipping = new List<string>();
            string query = "select address, state, city, zip from ShippingAddress where shipping_id = @id";
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
                            address = reader.GetString(0);
                            state = reader.GetString(1);
                            city = reader.GetString(2);
                            zip = reader.GetString(3);
                        }
                    }
                    cmd.Connection.Close();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }
            shipping.Add(address);
            shipping.Add(state);
            shipping.Add(city);
            shipping.Add(zip);
            return shipping;
        }

        [HttpPut("{id}/{address}/{state}/{city}/{zip}")]
        public void Put(int id, string address, string state, string city, string zip)
        {
            string query = "update ShippingAddress set address = @address, state = @state, city = @city, zip = @zip where shipping_id = @id;";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@address", System.Data.SqlDbType.NVarChar, 255);
                cmd.Parameters.Add("@state", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@city", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@zip", System.Data.SqlDbType.NVarChar, 10);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);

                cmd.Parameters["@address"].Value = address;
                cmd.Parameters["@state"].Value = state;
                cmd.Parameters["@city"].Value = city;
                cmd.Parameters["@zip"].Value = zip;
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
