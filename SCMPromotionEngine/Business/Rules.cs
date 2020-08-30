using SCMPromotionEngine;
using SCMPromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCMPromotionEngine
{

    public class BasicRule : ProductsDB
    {
        protected List<ProductDto> _productList;

        public BasicRule(List<ProductDto> productList)
        {
            _productList = productList;
        }

        public virtual void TotalPriceCalculation()
        {
            Console.WriteLine("Below Cart without any Discount");
            double totalAmount = 0;
            foreach (var item in _productList)
            {
                var product = products.Where(p => p.SKU == item.SKU).FirstOrDefault();
                double subTotal = product.ProductPrice * item.OrderedQty;
                Console.WriteLine(item.OrderedQty + " * " + product.SKU + "     " + subTotal);
                totalAmount += subTotal;
            }
            Console.WriteLine("Total amount for above cart is " + totalAmount);
            Console.WriteLine("---------------------------");
        }

    }

    public class DiscountRules : BasicRule
    {
        IRuleEngine ruleEngine;
        public DiscountRules(List<ProductDto> productList) : base(productList)
        {
            _productList = productList;
            foreach (var item in _productList)
            {
                var product = products.Where(p => p.SKU == item.SKU).FirstOrDefault();
                item.OfferGroupId = product.OfferGroupId;
                item.ProductPrice = product.ProductPrice;
            }
        }

        public override void TotalPriceCalculation()
        {
            Console.WriteLine("Below Cart with Discounts");
            double totalAmount = 0;

            var rulesId = _productList.Where(grp=>grp.OfferGroupId!=null).Select(x => x.OfferGroupId).Distinct().ToList();
            foreach (var Id in rulesId)
            {
                var rule = groupPromotions.Where(gp => gp.OfferGroupId == Id).FirstOrDefault();
                switch (rule.OfferType)
                {
                    case "flat":
                        ruleEngine = new FlatDiscount(rule.MinimumDiscountQty, rule.DiscountValue);
                        var flatDiscountProducts = _productList.Where(prd => prd.OfferGroupId == rule.OfferGroupId).ToList();
                        ruleEngine.GetDiscountedPrice(flatDiscountProducts);
                        break;
                    case "combo":
                        ruleEngine = new ComboDiscount(rule.MinimumDiscountQty, rule.DiscountValue);
                        var comboDiscountProducts = _productList.Where(prd => prd.OfferGroupId == rule.OfferGroupId).ToList();
                        ruleEngine.GetDiscountedPrice(comboDiscountProducts);
                        break;
                    default:
                        // double subTotal = product.ProductPrice * item.OrderedQty;
                        break;
                }
            }
            var nonGroupProducts = _productList.Where(prd => prd.OfferGroupId == null).ToList();
            foreach (var product in nonGroupProducts)
            {
                product.SubTotal = product.ProductPrice * product.OrderedQty;
                Console.WriteLine(product.OrderedQty + " * " + product.SKU + "      " + product.SubTotal);
            }
            totalAmount = _productList.Sum(product => product.SubTotal);
            Console.WriteLine("Total amount for above cart is " + totalAmount);
        }

    }

}

