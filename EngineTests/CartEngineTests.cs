using Engines;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EngineTests
{
    [TestClass]
    public class CartEngineTests
    {
        [TestMethod]
        public void calculateItemCost_noSale_fiveDollarItem_threeItems()
        {
            ICartEngine engine = new CartEngine();
            double sale = 0;
            double price = 5;
            int units = 3;

            Assert.AreEqual(15, engine.calculateItemCost(sale, units, price), .0001);
        }

        [TestMethod]
        public void calculateItemCost_fiftyPct_eightThirtyItem_twelveItems()
        {
            ICartEngine engine = new CartEngine();
            double sale = .5;
            double price = 8.30;
            int units = 12;

            Assert.AreEqual(49.8, engine.calculateItemCost(sale, units, price), .0001);
        }

        [TestMethod]
        public void calculateItemCost_thirtyPct_twoDollarItem_oneItem()
        {
            ICartEngine engine = new CartEngine();
            double sale = .3;
            double price = 2;
            int units = 1;

            Assert.AreEqual(1.4, engine.calculateItemCost(sale, units, price), .0001);
        }

        [TestMethod]
        public void calculateTotal_emptyCart()
        {
            ICartEngine engine = new CartEngine();
            List<double> itemCosts = new List<double>();

            Assert.AreEqual(0, engine.calculateTotal(itemCosts), .0001);
        }

        [TestMethod]
        public void calculateTotal_sixFifty_eightSixtyThree_thirteenDollars()
        {
            ICartEngine engine = new CartEngine();
            List<double> itemCosts = new List<double>();
            itemCosts.Add(6.5);
            itemCosts.Add(8.63);
            itemCosts.Add(13);

            Assert.AreEqual(28.13, engine.calculateTotal(itemCosts), .0001);
        }

        [TestMethod]
        public void calculateTotal_fiftyDollarsAndSeventyThreeCents()
        {
            ICartEngine engine = new CartEngine();
            List<double> itemCosts = new List<double>();
            itemCosts.Add(50.73);

            Assert.AreEqual(50.73, engine.calculateTotal(itemCosts), .0001);
        }

        [TestMethod]
        public void calculateTotalWithTax_Nebraska_Eighty()
        {
            ICartEngine engine = new CartEngine();

            Assert.AreEqual(80.0, engine.calculateTotalWithTax(80, "NE"), .0001);
        }

        [TestMethod]
        public void calculateTotalWithTax_NoState_FiftyThreeSixty()
        {
            ICartEngine engine = new CartEngine();

            Assert.AreEqual(53.60, engine.calculateTotalWithTax(53.6), .0001);
        }

        [TestMethod]
        public void calculateTotalWithTax_Oklahoma_TenDollars()
        {
            ICartEngine engine = new CartEngine();

            Assert.AreEqual(10.45, engine.calculateTotalWithTax(10, "OK"), .0001);
        }
    }
}
