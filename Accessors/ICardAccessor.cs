using System;
using System.Collections.Generic;

namespace Accessors
{
    public interface ICardAccessor
    {
        List<String> RetrieveCardInfo(int userId);

        void UpdateCardInfo(int userId, string name, string num, string cvv, string date_month, string date_year);
    }
}