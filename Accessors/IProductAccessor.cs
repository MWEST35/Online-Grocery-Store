using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Accessors
{
    public interface IProductAccessor
    {
        List<List<String>> getProducts(SqlConnection conn);
        
    }
}
