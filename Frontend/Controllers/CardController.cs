using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        SqlConnection conn =
            new SqlConnection("data source = Kalelius\\SQLEXPRESS; initial catalog = grocery; TrustServerCertificate = True; user id = sa; password = sixpeasinapod");

        [HttpGet("{id}")]
        public List<string> Get(int id)
        {
            string name = "";
            string cardNumber = "";
            string cvv = "";
            string date = "";
            List<string> card = new List<string>();
            string query = "select name, cardNumber, cvv, expDate from Card where card_id = @id";
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
                            cardNumber = reader.GetString(1);
                            cvv = reader.GetString(2);
                            date = reader.GetString(3);
                        }
                    }
                    cmd.Connection.Close();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }
            card.Add(name);
            card.Add(cardNumber);
            card.Add(cvv);
            card.Add(date);
            return card;
        }

        [HttpPut("{id}/{name}/{num}/{cvv}/{date_month}/{date_year}")]
        public void Put(int id, string name, string num, string cvv, string date_month, string date_year)
        {
            string query = "update Card set name = @name, cardNumber = @num, cvv = @cvv, expDate = @date where card_id = @id";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@num", System.Data.SqlDbType.NVarChar, 19);
                cmd.Parameters.Add("@cvv", System.Data.SqlDbType.NVarChar, 3);
                cmd.Parameters.Add("@date", System.Data.SqlDbType.NVarChar, 5);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);

                cmd.Parameters["@name"].Value = name;
                cmd.Parameters["@num"].Value = num;
                cmd.Parameters["@cvv"].Value = cvv;
                cmd.Parameters["@date"].Value = $"{date_month}/{date_year}";
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
