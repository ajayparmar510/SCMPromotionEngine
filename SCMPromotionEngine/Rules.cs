using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCMPromotionEngine
{
    class Rules:IRuleEngine
    {
        public int TotalAmount{ get; set; }
        public int DiscountRule(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.BulkDiscountMinQty < product.OrderedQty)
                {

                    int reminder = product.OrderedQty / product.BulkDiscountMinQty;
                    int discount = (reminder*product.Discount);
                    int remCalc= (product.OrderedQty * product.Price) -discount;
                    product.SubTotal = remCalc;

                }
                else
                {
                    product.SubTotal = product.OrderedQty * product.Price;
                }
            }


            TotalAmount= products.Sum(product => product.SubTotal);
            return TotalAmount;
        }

               
    }




    
}
