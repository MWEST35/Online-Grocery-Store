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
    internal class CartAccessor : ICartAccessor
    {
       
        List<string> ICartAccessor.retrieveItems(string cartId, SqlConnection conn)
        {
            List<string> items = new List<string>();

            string query = "SELECT p.productName FROM product p INNER JOIN cart c ON c.cart_id = p.cartId WHERE c.cart_id = @cart_id";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@cart_id", cartId);
                cmd.Connection = conn;
                try
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string productName = reader.GetString(0);
                            items.Add(productName);
                        }
                    }
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }

            return items;
        }

        void ICartAccessor.addItem(string cartId, string productId, SqlConnection conn)
        {
            string query = "INSERT INTO Cart(product_id, quantity) SELECT productId, 1 FROM product WHERE productId = @productId";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@productId", productId);
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }

        void ICartAccessor.removeItem(string cartId, string productId, SqlConnection conn)
        {
            string query = "DELETE FROM Cart WHERE cart_id = @cartId AND product_id = @productId";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.AddWithValue("@cartId", cartId);
                cmd.Parameters.AddWithValue("@productId", productId);
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }
        }
    }

}