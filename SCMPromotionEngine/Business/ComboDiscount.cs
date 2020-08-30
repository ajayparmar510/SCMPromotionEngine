using System;
using System.Collections.Generic;
using System.Linq;

namespace SCMPromotionEngine
{
    class ComboDiscount : IRuleEngine
    {
        private int _minimumDiscountQty;
        private double _discountValue;
        public ComboDiscount( int MinimumDiscountQty, double discountValue)
        {
            _minimumDiscountQty = MinimumDiscountQty;
            _discountValue = discountValue;
           
        }

        public void GetDiscountedPrice(List<ProductDto> productList)
        {
            if(productList.Count()==1)
            {
                var product = productList.FirstOrDefault();
                product.SubTotal = product.ProductPrice * product.OrderedQty;
                Console.WriteLine(product.OrderedQty + " * " + product.SKU + "      " + product.SubTotal);
                return;
            }
            var firstProduct = productList.FirstOrDefault();
            var secondProduct = productList.Skip(1).FirstOrDefault();
            if (firstProduct.OrderedQty==secondProduct.OrderedQty)
            {
                firstProduct.SubTotal = 0;
                // Console.WriteLine("Sku: " + firstProduct.SKU + " ,Quantity: " + firstProduct.OrderedQty + " ,Price: " + firstProduct.ProductPrice + " ,Sub Total: " + firstProduct.SubTotal);
                secondProduct.SubTotal = firstProduct.OrderedQty * (firstProduct.ProductPrice + secondProduct.ProductPrice) - _discountValue;
                // Console.WriteLine("Sku: " + secondProduct.SKU + " ,Quantity: " + secondProduct.OrderedQty + " ,Price: " + secondProduct.ProductPrice + " ,Sub Total: " + secondProduct.SubTotal);

                Console.WriteLine(firstProduct.OrderedQty + " * " + firstProduct.SKU + "      -" );
                Console.WriteLine(secondProduct.OrderedQty + " * " + secondProduct.SKU + "      "+ secondProduct.SubTotal);
            }
            else if(firstProduct.OrderedQty>secondProduct.OrderedQty)
            {
                var modQuantity = firstProduct.OrderedQty / secondProduct.OrderedQty;
                var reminderQty = firstProduct.OrderedQty % secondProduct.OrderedQty;
                int qtyDifference = firstProduct.OrderedQty - secondProduct.OrderedQty;
                firstProduct.SubTotal = firstProduct.ProductPrice * qtyDifference;
                secondProduct.SubTotal = secondProduct.OrderedQty * (firstProduct.ProductPrice + secondProduct.ProductPrice) - _discountValue * secondProduct.OrderedQty;

                //Console.WriteLine("Sku: " + firstProduct.SKU + " ,Quantity: " + qtyDifference + " ,Price: " + firstProduct.ProductPrice + " ,Sub Total: " + firstProduct.SubTotal);
                //Console.WriteLine("Sku: " + secondProduct.SKU + " ,Quantity: " + secondProduct.OrderedQty + " ,Price: " + secondProduct.ProductPrice + " ,Sub Total: " + secondProduct.SubTotal);

                Console.WriteLine(firstProduct.OrderedQty + " * " + firstProduct.SKU + "        "+ firstProduct.SubTotal);
                Console.WriteLine(secondProduct.OrderedQty + " * " + secondProduct.SKU + "      " + secondProduct.SubTotal);
            }
            else
            {
                firstProduct.SubTotal = 0;
                int qtyDifference = secondProduct.OrderedQty - firstProduct.OrderedQty;
                secondProduct.SubTotal = secondProduct.ProductPrice * qtyDifference;
                secondProduct.SubTotal = firstProduct.OrderedQty * (firstProduct.ProductPrice + secondProduct.ProductPrice) - _discountValue;
                //Console.WriteLine("Sku: " + firstProduct.SKU + " ,Quantity: " + qtyDifference + " ,Price: " + firstProduct.ProductPrice + " ,Sub Total: " + firstProduct.SubTotal);
                //Console.WriteLine("Sku: " + secondProduct.SKU + " ,Quantity: " + secondProduct.OrderedQty + " ,Price: " + secondProduct.ProductPrice + " ,Sub Total: " + secondProduct.SubTotal);
                Console.WriteLine(firstProduct.OrderedQty + " * " + firstProduct.SKU + "        " + firstProduct.SubTotal);
                Console.WriteLine(secondProduct.OrderedQty + " * " + secondProduct.SKU + "      " + secondProduct.SubTotal);


            }
        }
    }

}

