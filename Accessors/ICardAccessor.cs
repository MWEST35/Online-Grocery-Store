using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Accessors
{
    public interface ICardAccessor
    {
        List<String> RetrieveCardInfo(int userId, SqlConnection conn);

        void UpdateCardInfo(int userId, string name, string num, string cvv, string date_month, string date_year, SqlConnection conn);
    }
}