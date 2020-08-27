using System;
using System.Collections.Generic;
using System.Text;

namespace SCMPromotionEngine
{
    interface IRuleEngine
    {
        int TotalAmount { get; set; }
        int DiscountRule(List<Product> products);
    }

}
