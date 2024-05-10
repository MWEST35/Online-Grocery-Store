using Microsoft.SqlServer.Server;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Accessors
{
    public class ShippingAccessor : IShippingAccessor
    {

        List<string> IShippingAccessor.RetrieveAddress(int userId, SqlConnection conn)
        {
            string address = "";
            string state = "";
            string city = "";
            string zip = "";
            List<string> shippingAddress = new List<string>();
            string query = "select address, state, city, zip from ShippingAddress where user_id = @userId";
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
            shippingAddress.Add(address);
            shippingAddress.Add(state);
            shippingAddress.Add(city);
            shippingAddress.Add(zip);
            return shippingAddress;
        }

        void IShippingAccessor.updateAddress(int userId, string address, string state, string city, string zip, SqlConnection conn)
        {
            string query = "update ShippingAddress set address = @address, state = @state, city = @city, zip = @zip where user_id = @userId";
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
                cmd.Parameters["@userId"].Value = userId;
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
