using System;
using System.Collections.Generic;

namespace SCMPromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IRuleEngine discountRule = new Rules();

            List<Product> productListScenarioA = new List<Product>
            {
                new Product{ SKU='A', Price=50, BulkDiscountMinQty=3, Discount=20, OrderedQty=1},
                new Product{ SKU='B', Price=30, BulkDiscountMinQty=2, Discount=15, OrderedQty=1},
                new Product{ SKU='C', Price=20, BulkDiscountMinQty=1, Discount=0, OrderedQty=1}
            };
            List<Product> productListScenarioB = new List<Product>
            {
                new Product{ SKU='A', Price=50, BulkDiscountMinQty=3, Discount=20, OrderedQty=5},
                new Product{ SKU='B', Price=30, BulkDiscountMinQty=2, Discount=15, OrderedQty=5},
                new Product{ SKU='C', Price=20, BulkDiscountMinQty=1, Discount=0, OrderedQty=1}
            };

            List<Product> productListScenarioC = new List<Product>
            {
                new Product{ SKU='A', Price=50, BulkDiscountMinQty=3, Discount=20, OrderedQty=5},
                new Product{ SKU='B', Price=30, BulkDiscountMinQty=2, Discount=15, OrderedQty=5},
                new Product{ SKU='C', Price=20, BulkDiscountMinQty=1, Discount=0, OrderedQty=1},
                new Product{ SKU='D', Price=15, BulkDiscountMinQty=1, Discount=0, OrderedQty=1}
            };

            Console.WriteLine("Scenario A Total amount: "+ discountRule.DiscountRule(productListScenarioA));
            Console.WriteLine("Scenario B Total amount: " + discountRule.DiscountRule(productListScenarioB));
            Console.WriteLine("Scenario C Total amount: " + discountRule.DiscountRule(productListScenarioC));

            Console.ReadKey();
        }
    }
}
