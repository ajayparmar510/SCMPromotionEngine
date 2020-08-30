using System;
using System.Collections.Generic;
using System.Text;

namespace SCMPromotionEngine.Model
{
    interface ICart
    {
        void AddToCart(string SKU,int Quantity);
        void DisplayOriginalPrice();
        
    }

    interface IPromotion
    {
        void ApplyPromotion();
    }
   
}
