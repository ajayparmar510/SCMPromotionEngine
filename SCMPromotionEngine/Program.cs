using SCMPromotionEngine.Business;
using SCMPromotionEngine.Model;
using System;
using System.Collections.Generic;

namespace SCMPromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Scenario A ");
            Cart cartA = new Cart();
            cartA.AddToCart("A", 1);
            cartA.AddToCart("B", 1);
            cartA.AddToCart("C", 1);
            //cartA.DisplayOriginalPrice();
            cartA.ApplyPromotion();
            Console.WriteLine();

            Console.WriteLine("Scenario B ");
            Cart cartB = new Cart();
            cartB.AddToCart("A", 5);
            cartB.AddToCart("B", 5);
            cartB.AddToCart("C", 1);
            //cartB.DisplayOriginalPrice();
            cartB.ApplyPromotion();
            Console.WriteLine();

            Console.WriteLine("Scenario C ");
            Cart cartC= new Cart();
            cartC.AddToCart("A", 3);
            cartC.AddToCart("B", 5);
            cartC.AddToCart("C", 1);
            cartC.AddToCart("D", 1);
            //cartC.DisplayOriginalPrice();
            cartC.ApplyPromotion();
            Console.WriteLine();

            Console.WriteLine("Scenario D - Item E is no-offer item");
            cartC.AddToCart("E", 1); //without offer item
            //cartC.DisplayOriginalPrice();
            cartC.ApplyPromotion();

            Console.ReadKey();
        }
    }
}
