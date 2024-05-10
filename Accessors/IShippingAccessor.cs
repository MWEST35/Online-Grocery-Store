using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient

namespace Accessors
{
    public interface IShippingAccessor
    {
        List<String> RetrieveAddress(int userId, SqlConnection conn);

        void UpdateAddress(int userId, string address, string state, string city, string zip, SqlConnection conn);
    }
}