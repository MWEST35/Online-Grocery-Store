using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<string> RetrieveItems(string product_id)
        {
            List<string> items = new List<string>();

            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();

                string query = "SELECT p.productName FROM product p INNER JOIN cart c ON c.product_id = p.productId WHERE c.product_id = @product_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@product_id", product_id);
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

        public void RemoveItem(string cartId, string itemId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();
                string query = "DELETE FROM Cart WHERE cart_id = @cartId AND product_id = @itemId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cartId", cartId);
                cmd.Parameters.AddWithValue("@itemId", itemId);
                cmd.ExecuteNonQuery();
            }
        }
    }

}