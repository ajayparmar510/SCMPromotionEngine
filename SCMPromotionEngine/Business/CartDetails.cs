using SCMPromotionEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCMPromotionEngine.Business
{
    class Cart : ProductsDB,ICart,IPromotion
    {
        public ProductDto Item;
        public List<ProductDto> ItemList = new List<ProductDto>();

        public void AddToCart(string SKU, int Quantity)
        {
            Item = new ProductDto();
            Item.SKU = SKU;
            Item.OrderedQty = Quantity;
            ItemList.Add(Item);
        }
        
        public void ApplyPromotion()
        {
            var discountRules = new DiscountRules(ItemList);
            discountRules.TotalPriceCalculation();
        }

        public void DisplayOriginalPrice()
        {
            var basicDiscount = new BasicRule(ItemList);
            basicDiscount.TotalPriceCalculation();
        }

        
    }
}
