using System;
using System.Collections.Generic;

namespace SCMPromotionEngine
{
    class FlatDiscount : IRuleEngine
    {
        private int _minimumDiscountQty;
        private double _discountValue;
        public FlatDiscount(int MinimumDiscountQty, double discountValue)
        {
            _minimumDiscountQty = MinimumDiscountQty;
            _discountValue = discountValue;
        }
        public void GetDiscountedPrice(List<ProductDto> productList)
        {
            foreach (var product in productList)
            {
                int modQuantity, remQuantity = 0;
                double remCalc,modCalc, discount = 0;
                if (_minimumDiscountQty <= product.OrderedQty)
                {
                    remQuantity = product.OrderedQty % _minimumDiscountQty;
                    modQuantity = product.OrderedQty / _minimumDiscountQty;
                    discount = (modQuantity * _discountValue);
                    modCalc = (_minimumDiscountQty* modQuantity * product.ProductPrice) - discount;
                    remCalc = remQuantity * product.ProductPrice;
                    product.SubTotal = modCalc+ remCalc;

                    Console.WriteLine(product.OrderedQty + " * " + product.SKU + "      " +modCalc+" + "+ remQuantity+ "*"+product.ProductPrice+" = "+product.SubTotal );

                }
                else
                {
                    product.SubTotal = product.OrderedQty * product.ProductPrice;
                    Console.WriteLine(product.OrderedQty + " * " + product.SKU + "      " + product.SubTotal);

                }

               

               // Console.WriteLine("Sku: " + product.SKU + " ,Quantity: " + product.OrderedQty + " ,Price: " + product.ProductPrice + " ,Sub Total: " + product.SubTotal);

            }
        }
    }

}

