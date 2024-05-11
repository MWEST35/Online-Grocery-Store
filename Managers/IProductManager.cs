using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Managers
{
    public interface IProductManager
    {
        List<List<string>> retrieveProductInformation();

        void addToCartOrRemoveFromCart(int productId, int cartId, bool add);
        List<List<string>> getProductsInCart(Int32 cartId);
    }
}
