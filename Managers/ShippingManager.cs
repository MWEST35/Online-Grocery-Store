using System.Collections.Generic;
using System;
using Accessors;

namespace Managers
{
    public class ShippingManager : IShippingManager
    {
        private IShippingAccessor shippingAccessor = new ShippingAccessor();
        IConnectionAccessor connectionAccessor = new ConnectionAccessor();
        List<string> IShippingManager.RetrieveAddress(int userId)
        {
            return shippingAccessor.RetrieveAddress(userId, connectionAccessor.createConnection());
        }

        void IShippingManager.UpdateAddress(int userId, string address, string state, string city, string zip)
        {
            shippingAccessor.UpdateAddress(userId, address, state, city, zip, connectionAccessor.createConnection());
            return;
        }
    }
}