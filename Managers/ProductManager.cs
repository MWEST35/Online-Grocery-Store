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
        List<List<string>> IProductManager.retrieveProductInformation()
        {
            return productAccessor.getProducts(productAccessor.createConnection());
        }
    }
}
