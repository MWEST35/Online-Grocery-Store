using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Accessors
{
    public class ConnectionAccessor : IConnectionAccessor
    {
        SqlConnection IConnectionAccessor.createConnection()
        {
            SqlConnection conn =
                new SqlConnection("data source = JACK\\SQLEXPRESS; initial catalog = grocery; TrustServerCertificate = True; Trusted_Connection=True");
            return conn;
        }
    }
}
