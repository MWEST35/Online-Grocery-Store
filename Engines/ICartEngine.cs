using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engines
{
    internal interface ICartEngine
    {
        // Allows printing a single item's cost for receipt
        double calculateItemCost(float salePct, int units, double pricePerUnit);

        // Allows printing the taxless total for receipt
        double calculateTotal(List<double> itemCosts);

        // Generates the total
        double totalWithTax(double gross);
    }
}
