using System;

namespace Managers
{
    public interface ICartManager
    {
        Int32 getUsersCart(Int32 userId);

        void checkoutCart(Int32 cartId);
    }
}