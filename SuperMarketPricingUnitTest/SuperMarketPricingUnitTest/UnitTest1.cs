using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using SuperMarketProject;

namespace SuperMarketPricingUnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        
        [TestCase(500, "grape", 0, 0.10, -1, -1, -1)] //total weight(grams), item name, discount, price per gram, priceperitem, specialDiscount
        public void TestPriceWeight(double weight, string name, int discount, double pricePerGram, double pricePerItem, params double[] specialDiscount)
        {
            List<Item> cart = new List<Item>();
            Item item = new Item(name, discount, pricePerGram, pricePerItem, specialDiscount);
            cart.Add(item);
            PricingSystem priceSystem = new PricingSystem(cart);
            Assert.AreEqual(priceSystem.ComputeTotalPrice(weight), 50.0);
       
        }

        [TestCase(3.0, 6, "Apple", 0, -1, 0.50, -1, -1)] //Quantity,item name, discount, price per gram, price per item, specialDiscount (w/o special discount)
        [TestCase(2.0, 6, "Apple", 0, -1, 0.50, 3, 1)] // (w special discount 3 for $1)
        [TestCase(1.50, 6, "Apple", 50, -1, 0.50, -1, -1)] // special price for each apple (w no special discount)

        [TestCase(2.0, 8, "Apple", 50, -1, 0.50, 3, 1)] // special price for each apple (w special discount) - choose the lower price for consumer
        // e.g. 50% discount for all apples => $2 & special discount 3 for $1 => $2 + $0.50 + $0.50 = $3 => the consumer will be charged $2


        public void TestPriceQuantity(double expectedResult, int quantity, string name, int discount, double pricePerGram, double pricePerItem, params double[] specialDiscount)
        {
            List<Item> cart = new List<Item>();
            Item item = new Item(name, discount, pricePerGram, pricePerItem, specialDiscount);
            cart.Add(item);
            PricingSystem priceSystem = new PricingSystem(cart);
            Assert.AreEqual(priceSystem.ComputeTotalPrice(quantity), expectedResult);
        }


    }
}
