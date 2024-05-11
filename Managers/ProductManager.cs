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

        List<List<string>> IProductManager.getProductsInCart(Int32 cartId)
        {
            return productAccessor.getProductsInCart(cartId, connectionAccessor.createConnection());
        }
        void IProductManager.addToCartOrRemoveFromCart(int productId, int cartId, bool add)
        {
            if (add)
            {
                productAccessor.addToCart(productId, cartId, connectionAccessor.createConnection());
            }
            else
            {
                productAccessor.removeFromCart(productId, connectionAccessor.createConnection());
            }
            return;
        }
    }
}
