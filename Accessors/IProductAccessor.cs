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

        void addToCart(int productId, int cartId, SqlConnection conn);
        List<List<string>> getProductsInCart(int cartId, SqlConnection conn);
        void removeFromCart(int productId, SqlConnection conn);
    }
}
