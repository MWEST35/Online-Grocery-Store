using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;


namespace Frontend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{

		SqlConnection conn =
	new SqlConnection("data source = Kalelius\\SQLEXPRESS; initial catalog = grocery; TrustServerCertificate = True; user id = sa; password = sixpeasinapod");

		[HttpGet("{productName}/{rating}/{category}/{dimensions}/{weight}/{price}/{description}/{manufacturer}/{sku}")]
		public bool Get(string productName, int rating, string category, string dimensions, double weight, double price, string description, string manufacturer, int sku)
		{

			string query = "select productName, rating, category, dimensions, weight, price, description, manufacturer, sku " +
				"from product where productName = @productName and rating = @ratinf and category = @category and dimensions = @dimensions" +
				" and weight = @weight and price = @price and description = @description and manufacturer = @manufacturer and sku = @sku;";
			using (SqlCommand cmd = new SqlCommand(query))
			{
				cmd.Parameters.Add("@productName", System.Data.SqlDbType.NVarChar, 50);
				cmd.Parameters.Add("@rating", System.Data.SqlDbType.Int);
				cmd.Parameters.Add("@category", System.Data.SqlDbType.NVarChar, 50);
				cmd.Parameters.Add("@dimensions", System.Data.SqlDbType.VarChar, 50);
				cmd.Parameters.Add("@weight", System.Data.SqlDbType.Decimal);
				cmd.Parameters.Add("@price", System.Data.SqlDbType.Decimal);
				cmd.Parameters.Add("@description", System.Data.SqlDbType.Text);
				cmd.Parameters.Add("@sku", System.Data.SqlDbType.Int);


				cmd.Parameters["@productName"].Value = productName;
				cmd.Parameters["@rating"].Value = rating;
				cmd.Parameters["@category"].Value = category;
				cmd.Parameters["@dimensions"].Value = dimensions;
				cmd.Parameters["@weight"].Value = weight;
				cmd.Parameters["@price"].Value = price;
				cmd.Parameters["@description"].Value = description;
				cmd.Parameters["@sku"].Value = sku;
				cmd.Connection = conn;

				try
				{
					cmd.Connection.Open();
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							if (reader.GetString(0) == productName && reader.GetInt16(1) == rating
								 && reader.GetString(2) == category && reader.GetString(3) == dimensions
								 && reader.GetDecimal(4).Equals(weight) && reader.GetDecimal(5).Equals(price)
								 && reader.GetString(6) == description && reader.GetInt16(7) == sku)
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
	}
}