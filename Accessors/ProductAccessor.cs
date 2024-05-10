using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Accessors
{
    public class ProductAccessor : IProductAccessor
    {
        SqlConnection IProductAccessor.createConnection()
        {
            SqlConnection conn =
                new SqlConnection("data source = JACK\\SQLEXPRESS; initial catalog = grocery; TrustServerCertificate = True; Trusted_Connection=True");
            return conn;
        }

        List<List<string>> IProductAccessor.getProducts(SqlConnection conn)
        {
            List<List<String>> products = new List<List<String>>();
            string query = "select productName, rating, category, dimensions, weight, price, description, manufacturer, sku, product_id from Product where cart_id is null";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = conn;

                try
                {
                    cmd.Connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            List<String> product = new List<String>();
                            string productName = reader.GetString(0);
                            product.Add(productName);
                            string rating = reader.GetInt32(1).ToString();
                            product.Add(rating);
                            string category = reader.GetString(2);
                            product.Add(category);
                            string dimensions = reader.GetString(3);
                            product.Add(dimensions);
                            string weight = reader.GetDecimal(4).ToString();
                            product.Add(weight);
                            string price = reader.GetDecimal(5).ToString();
                            product.Add(price);
                            string description = reader.GetString(6);
                            product.Add(description);
                            string manufacturer = reader.GetString(7);
                            product.Add(manufacturer);
                            string sku = reader.GetInt32(8).ToString();
                            product.Add(sku);
                            string productId = reader.GetInt32(9).ToString();
                            product.Add(productId);
                            products.Add(product);
                        }
                    }

                    cmd.Connection.Close();
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
            }

            return products;
        }

    }
}
