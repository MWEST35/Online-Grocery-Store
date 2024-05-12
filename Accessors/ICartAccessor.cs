using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors
{
    public interface ICartAccessor
    {
        Int32 getUsersCart(Int32 userId, SqlConnection conn);

        void checkoutCart(Int32 cartId, SqlConnection conn);

    }
}
