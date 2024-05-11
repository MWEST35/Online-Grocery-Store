using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Frontend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        SqlConnection conn =
            new SqlConnection("data source = Kalelius\\SQLEXPRESS; initial catalog = grocery; TrustServerCertificate = True; user id = sa; password = sixpeasinapod");

        [HttpGet("{userId}")]
        public Int32 Get(Int32 userId)
        {
            Int32 result = 0;
            string query = "select cart_id from Cart where user_id = @userId";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@userId", System.Data.SqlDbType.Int);

                cmd.Parameters["@userId"].Value = userId;
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

        [HttpDelete("{cartId}")]
        public void Delete(Int32 cartId)
        {
            string query = "delete from Product where cart_id = @cartId";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@cartId", System.Data.SqlDbType.Int);

                cmd.Parameters["@cartId"].Value = cartId;
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
