using System;
using System.Collections.Generic;
using System.Text;

namespace SCMPromotionEngine
{
    interface IRuleEngine
    {
        int TotalAmount { get; set; }
        void DiscountRule(List<Product> products);
    }
}
