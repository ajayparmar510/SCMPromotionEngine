using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCMPromotionEngine
{
    class Rules:IRuleEngine
    {
        public int TotalAmount{ get; set; }
        public void DiscountRule(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.BulkDiscountMinQty < product.OrderedQty)
                {

                    int reminder = product.OrderedQty / product.BulkDiscountMinQty;
                    int mod = product.OrderedQty % product.BulkDiscountMinQty;

                    int modCalc = mod * product.Price;
                    int remCalc = reminder * (product.Price * product.DiscountPercent);
                    product.SubTotal = modCalc + remCalc;

                }
                else
                {
                    product.SubTotal = product.OrderedQty * product.Price;
                }
            }
            TotalAmount= products.Sum(product => product.SubTotal);
        }

        
    }




    
}
