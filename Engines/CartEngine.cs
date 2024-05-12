using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Engines
{
    public class CartEngine : ICartEngine
    {

        double ICartEngine.calculateItemCost(double salePct, int units, double pricePerUnit)
        {
            double saleApplied = pricePerUnit * (1 - salePct);
            return Math.Round((saleApplied * units), 2);
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

        double ICartEngine.calculateTotalWithTax(double gross, string state = "")
        {
            double taxRate = 0;
            // Find the tax rate for the user's state of residence. Defaults to NE
            switch (state)
            {
                case "AL":
                    taxRate = .03;
                    break;
                case "AR":
                    taxRate = .00125;
                    break;
                case "HI":
                    taxRate = .0444;
                    break;
                case "ID":
                    taxRate = .06;
                    break;
                case "IL":
                    taxRate = .01;
                    break;
                case "KS":
                    taxRate = .02;
                    break;
                case "MS":
                    taxRate = .07;
                    break;
                case "MO":
                    taxRate = .01225;
                    break;
                case "OK":
                    taxRate = .045;
                    break;
                case "SD":
                    taxRate = .042;
                    break;
                case "TN":
                    taxRate = .04;
                    break;
                case "UT":
                    taxRate = .03;
                    break;
                case "VA":
                    taxRate = .01;
                    break;
                default:
                    taxRate = .0;
                    break;
            }

            return Math.Round(gross + (gross * taxRate), 2);
        }
    }
}
