using System.Collections.Generic;
using System;

namespace Managers
{
    public interface ICardManager
    {
        List<String> RetrieveCardInfo(int userId);

        void UpdateCardInfo(int userId, string name, string num, string cvv, string date_month, string date_year);
    }
}