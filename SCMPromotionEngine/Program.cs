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
                new Product{ SKU='A', Price=50, BulkDiscountMinQty=3, DiscountPercent=13, OrderedQty=1},
                new Product{ SKU='B', Price=30, BulkDiscountMinQty=2, DiscountPercent=25, OrderedQty=1},
                new Product{ SKU='C', Price=20, BulkDiscountMinQty=1, DiscountPercent=0, OrderedQty=1}
            };
            discountRule.DiscountRule(productListScenarioA);
            Console.WriteLine("Total amount "+discountRule.TotalAmount);
            Console.ReadKey();
        }
    }
}
