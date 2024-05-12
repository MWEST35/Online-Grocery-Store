using System;
using System.Collections.Generic;

namespace Managers
{
    public interface ICartManager
    {
        Int32 getUsersCart(Int32 userId);

        void checkoutCart(Int32 cartId);
        double getTotal(List<double> prices, bool withTax, string state);
    }
}