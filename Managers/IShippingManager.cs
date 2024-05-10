using System.Collections.Generic;
using System;

namespace Managers
{
    public interface IShippingManager
    {
        List<String> RetrieveAddress(int userId);

        void UpdateAddress(int userId, string address, string state, string city, string zip);
    }
}