using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessors
{
    internal class CartAccessor: ICartAccessor
    {
        SqlConnection ICartAccessor.createConnection()
        {
            string connString = @"data source=5ada07625c51;initial catalog=Project_grocery;user id=sa;password=Chocolate@12";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }

        public List<string> ICartAccessor.retrieveItems(string cartId)
        {
            throw new NotImplementedException();
        }

        public void ICartAccessor.addItem(string cartId, string itemId)
        {
            throw new NotImplementedException();
        }

        public void ICartAccessor.removeItem(string cartId, string itemId)
        {
            throw new NotImplementedException();
        }
    }
}
