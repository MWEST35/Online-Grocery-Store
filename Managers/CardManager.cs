using System.Collections.Generic;
using System;
using Accessors;

namespace Managers
{
    public class CardManager : ICardManager
    {
        private ICardAccessor cardAccessor = new CardAccessor();
        List<string> ICardManager.RetrieveCardInfo(int userId)
        {
            return cardAccessor.RetrieveCardInfo(userId);
        }

        void ICardManager.UpdateCardInfo(int userId, string name, string num, string cvv, string date_month, string date_year)
        {
            cardAccessor.UpdateCardInfo(userId, name, num, cvv, date_month, date_year);
            return;
        }
    }
}