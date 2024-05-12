using Accessors;
using System;

namespace Managers
{
    public class CartManager : ICartManager
    {
        ICartAccessor cartAccessor = new CartAccessor();
        IConnectionAccessor connectionAccessor = new ConnectionAccessor();
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