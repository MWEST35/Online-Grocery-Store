using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Accessors
{
    internal class CartAccessor : ICartAccessor
    {
        private SqlConnection CreateConnection()
        {
            string connString = @"data source=5ada07625c51;initial catalog=Project_grocery;user id=sa;password=Chocolate@12";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }

        public List<string> RetrieveItems(string cart_id)
        {
            List<string> items = new List<string>();

            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();

                string query = "SELECT p.productName FROM product p INNER JOIN cart c ON c.cart_id = p.cartId WHERE c.cart_id = @cart_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@product_id", product_id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string productName = reader.GetString(0);
                        items.Add(productName);
                    }
                }
            }

            return items;
        }

        public void AddItem(string cartId, string productId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();
                string query = "INSERT INTO Cart(product_id, quantity) SELECT productId, 1 FROM product WHERE productId = @productId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveItem(string cartId, string productId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();
                string query = "DELETE FROM Cart WHERE cart_id = @cartId AND product_id = @productId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cartId", cartId);
                //cmd.Parameters.AddWithValue("@itemId", itemId);
                cmd.ExecuteNonQuery();
            }
        }

        public System.Data.SqlClient.SqlConnection createConnection()
        {
            throw new NotImplementedException();
        }

        public List<string> retrieveItems(string cartId)
        {
            throw new NotImplementedException();
        }

        public void addItem(string cartId, string itemId)
        {
            throw new NotImplementedException();
        }

        public void removeItem(string cartId, string itemId)
        {
            throw new NotImplementedException();
        }
    }

}