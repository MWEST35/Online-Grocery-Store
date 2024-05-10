using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors
{
    internal interface ICartAccessor
    {
        List<string> retrieveItems(string cartId);
        void addItem(string cartId, string productId);
        void removeItem(string cartId, string productId);

    }
}
