using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors
{
    internal interface ICartAccessor
    {
        sqlConnection createConnection();
        List<string> retrieveItems(string cartId);
        void addItem(string cartId, string itemId);
        void removeItem(string cartId, string itemId);

    }
}
