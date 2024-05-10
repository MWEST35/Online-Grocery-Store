using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessors;
using Microsoft.Data.SqlClient;

namespace Managers
{
    public class ProductManager : IProductManager
    {
        IProductAccessor productAccessor = new ProductAccessor();
        IConnectionAccessor connectionAccessor = new ConnectionAccessor();
        List<List<string>> IProductManager.retrieveProductInformation()
        {
            return productAccessor.getProducts(connectionAccessor.createConnection());
        }
    }
}
