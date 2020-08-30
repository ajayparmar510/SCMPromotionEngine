using System;
using System.Collections.Generic;
using System.Text;

namespace SCMPromotionEngine
{

    public abstract class ProductsDB
    {
        public List<ProductDto> products = new List<ProductDto>();
        public List<DiscountOffersDto> groupPromotions = new List<DiscountOffersDto>();

        public ProductsDB()
        {
            
            products.Add(new ProductDto { ProductId = 1, SKU = "A", ProductPrice = 50.0, OfferGroupId = 1 });
            products.Add(new ProductDto { ProductId = 2, SKU = "B", ProductPrice = 30.0, OfferGroupId = 2 });
            products.Add(new ProductDto { ProductId = 3, SKU = "C", ProductPrice = 20.0, OfferGroupId = 3 });
            products.Add(new ProductDto { ProductId = 4, SKU = "D", ProductPrice = 15.0, OfferGroupId = 3 });
            products.Add(new ProductDto { ProductId = 5, SKU = "E", ProductPrice = 40.0, OfferGroupId = null });


            groupPromotions.Add(new DiscountOffersDto { OfferGroupId = 1, ProductId = 1, OfferType = "flat", MinimumDiscountQty = 3, DiscountValue = 20.0 });
            groupPromotions.Add(new DiscountOffersDto { OfferGroupId = 2, ProductId = 2, OfferType = "flat", MinimumDiscountQty = 2, DiscountValue = 15.0 });
            groupPromotions.Add(new DiscountOffersDto { OfferGroupId = 3, ProductId = 3, OfferType = "combo", MinimumDiscountQty = 2, DiscountValue = 5.0 });


        }
    }
}
