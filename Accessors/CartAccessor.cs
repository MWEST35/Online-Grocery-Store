using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Accessors
{
    public class CartAccessor : ICartAccessor
    {
        Int32 ICartAccessor.getUsersCart(Int32 userId, SqlConnection conn)
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
        void ICartAccessor.checkoutCart(int cartId, SqlConnection conn)
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