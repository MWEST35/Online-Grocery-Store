using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Engines
{
    public class CartEngine
    {

        public double calculateItemCost(double salePct, int units, double pricePerUnit)
        {
            double saleApplied = pricePerUnit * (1 - salePct);
            return Math.Round((saleApplied * units), 2);
        }

        public double calculateTotal(List<double> itemCosts)
        {
            double gross = 0;
            for (int i = 0; i < itemCosts.Count; i++)
            {
                gross += itemCosts[i];
            }
            return gross;
        }

        public double calculateTotalWithTax(double gross, string state = "")
        {
            double taxRate = 0;
            // Find the tax rate for the user's state of residence. Defaults to NE
            switch (state)
            {
                case "AL":
                    taxRate = .04;
                    break;
                case "AK":
                    taxRate = .00;
                    break;
                case "AZ":
                    taxRate = .056;
                    break;
                case "AR":
                    taxRate = .065;
                    break;
                case "CA":
                    taxRate = .0725;
                    break;
                case "CO":
                    taxRate = .029;
                    break;
                case "CT":
                    taxRate = .0635;
                    break;
                case "DE":
                    taxRate = .00;
                    break;
                case "FL":
                    taxRate = .06;
                    break;
                case "GA":
                    taxRate = .04;
                    break;
                case "HI":
                    taxRate = .04;
                    break;
                case "ID":
                    taxRate = .06;
                    break;
                case "IL":
                    taxRate = .0625;
                    break;
                case "IN":
                    taxRate = .07;
                    break;
                case "IA":
                    taxRate = .06;
                    break;
                case "KS":
                    taxRate = .065;
                    break;
                case "KY":
                    taxRate = .06;
                    break;
                case "LA":
                    taxRate = .0445;
                    break;
                case "ME":
                    taxRate = .055;
                    break;
                case "MD":
                    taxRate = .06;
                    break;
                case "MA":
                    taxRate = .0625;
                    break;
                case "MI":
                    taxRate = .06;
                    break;
                case "MN":
                    taxRate = .0688;
                    break;
                case "MS":
                    taxRate = .07;
                    break;
                case "MO":
                    taxRate = .0423;
                    break;
                case "MT":
                    taxRate = .00;
                    break;
                case "NE":
                    taxRate = .055;
                    break;
                case "NV":
                    taxRate = .0685;
                    break;
                case "NH":
                    taxRate = .00;
                    break;
                case "NJ":
                    taxRate = .0663;
                    break;
                case "NM":
                    taxRate = .0488;
                    break;
                case "NY":
                    taxRate = .04;
                    break;
                case "NC":
                    taxRate = .0475;
                    break;
                case "ND":
                    taxRate = .05;
                    break;
                case "OH":
                    taxRate = .0575;
                    break;
                case "OK":
                    taxRate = .045;
                    break;
                case "OR":
                    taxRate = .00;
                    break;
                case "PA":
                    taxRate = .06;
                    break;
                case "RI":
                    taxRate = .07;
                    break;
                case "SC":
                    taxRate = .06;
                    break;
                case "SD":
                    taxRate = .042;
                    break;
                case "TN":
                    taxRate = .07;
                    break;
                case "TX":
                    taxRate = .0625;
                    break;
                case "UT":
                    taxRate = .061;
                    break;
                case "VT":
                    taxRate = .06;
                    break;
                case "VA":
                    taxRate = .053;
                    break;
                case "WA":
                    taxRate = .065;
                    break;
                case "WV":
                    taxRate = .06;
                    break;
                case "WI":
                    taxRate = .05;
                    break;
                case "WY":
                    taxRate = .04;
                    break;
                case "DC":
                    taxRate = .06;
                    break;
                default:
                    taxRate = .055;
                    break;
            }

            return Math.Round(gross + (gross * taxRate), 2);
        }
    }
}
