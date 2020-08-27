using System;
using System.Text;
using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace SCMPromotionEngineTests
{
    /// <summary>
    /// Summary description for RuleEngine
    /// /*
    //     Active Promotions  --> Customizable Rules Chart
    //     3x A for 130
    //     2x B for 45
    //     1x(C+D) for 30

    //     Unit Prices without Promo:
    //     A:50
    //     B:30
    //     C:20
    //     D:15

    //    Can be repersented in Rule Set As:
    //             A B C D.....S.P.
    //    Rule1    3 0 0 0 ..... 130
    //    Rule2    0 2 0 0 ..... 45
    //    Rule3    0 0 1 1 ..... 30
    /// </summary>
    
    public class RuleEngine
    {
       
        public RuleEngine()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        //Responsible for getting the S.P for a Promo
        //interface IPromoSellingPriceCalculator
        //{
        //    int getSellingPriceForRules(IEnmerable<Rule> rules, List<Products> products);   //Can use first applicable rule
        //    int getBestSellingPriceForRules(IEnmerable<Rule> rules, List<Products> products); // Apply all rules find the chepest price and return that / Optional
        //    bool isPromoApplicable(IEnmerable<Rule> rules, List<Products> products);
        //}

        //Given Test Cases
        // Count of A,B,C,D and exptected of isPromoApplicable
        [TestCase(1, 1, 1, 0, false)] //TC:1
        [TestCase(5, 5, 1, 0, true)] // TC:2
        [TestCase(3, 5, 1, 1, true)] // TC:3
        public static void isPromoApplicable(int countA, int countB, int countC, int countD, bool expectedValue) //Tests I
        {
            // Iterate in current promo rule engine and figure out if promo is applicable 
            // var impl = instance of a class implementing IPromoSellingPriceCalculator
            // var result = impl.isPromoApplicable();
            // Assert.AreEqual(expectedValue,result);
        }



        [TestCase]
        public static void alwaysPasses()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
