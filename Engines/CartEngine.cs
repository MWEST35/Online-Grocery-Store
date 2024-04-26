using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engines
{
    internal class CartEngine : ICartEngine
    {
        double ICartEngine.calculateItemCost(float salePct, int units, double pricePerUnit)
        {
            double saleApplied = pricePerUnit * (1 - salePct);
            return (salePct * units);
        }

        double ICartEngine.calculateTotal(List<double> itemCosts)
        {
            double gross = 0;
            for (int i = 0; i < itemCosts.Count; i++)
            {
                gross += itemCosts[i];
            }
            return gross;
        }

        double ICartEngine.totalWithTax(double gross)
        {
            // Assumes Nebraska sales tax
            return (gross + (gross * .055));
        }
    }
}
