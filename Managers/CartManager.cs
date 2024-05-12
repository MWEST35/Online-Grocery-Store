using Accessors;
using Engines;
using System;
using System.Collections.Generic;

namespace Managers
{
    public class CartManager : ICartManager
    {
        ICartAccessor cartAccessor = new CartAccessor();
        private ICartEngine cartEngine = new CartEngine();
        IConnectionAccessor connectionAccessor = new ConnectionAccessor();

        double ICartManager.getTotal(List<double> prices, bool withTax, string state)
        {
            if (withTax)
            {
                return cartEngine.calculateTotalWithTax(prices[0], state);
            }
            return cartEngine.calculateTotal(prices);
        }
        Int32 ICartManager.getUsersCart(Int32 userId)
        {
            return cartAccessor.getUsersCart(userId, connectionAccessor.createConnection());
        }
        void ICartManager.checkoutCart(Int32 cartId)
        {
            cartAccessor.checkoutCart(cartId, connectionAccessor.createConnection());
            return;
        }
    }
}