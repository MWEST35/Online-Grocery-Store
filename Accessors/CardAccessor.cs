using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Accessors
{
    public class CardAccessor : ICardAccessor
    {
        
        List<string> ICardAccessor.RetrieveCardInfo(int userId, SqlConnection conn)
        {
            string name = "";
            string cardNumber = "";
            string cvv = "";
            string date = "";
            List<string> card = new List<string>();
            string query = "select name, cardNumber, cvv, expDate from Card where user_id = @userId";
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
                            name = reader.GetString(0);
                            cardNumber = reader.GetString(1);
                            cvv = reader.GetInt32(2).ToString();
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

        void ICardAccessor.UpdateCardInfo(int userId, string name, string num, string cvv, string date_month, string date_year, SqlConnection conn)
        {
            string query = "update Card set name = @name, cardNumber = @num, cvv = @cvv, expDate = @date where user_id = @userId";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@num", System.Data.SqlDbType.NVarChar, 19);
                cmd.Parameters.Add("@cvv", System.Data.SqlDbType.NVarChar, 3);
                cmd.Parameters.Add("@date", System.Data.SqlDbType.NVarChar, 5);
                cmd.Parameters.Add("@userId", System.Data.SqlDbType.Int);

                cmd.Parameters["@name"].Value = name;
                cmd.Parameters["@num"].Value = num;
                cmd.Parameters["@cvv"].Value = cvv;
                cmd.Parameters["@date"].Value = $"{date_month}/{date_year}";
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