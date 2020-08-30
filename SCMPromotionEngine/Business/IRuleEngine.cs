using System;
using System.Collections.Generic;
using System.Text;

namespace SCMPromotionEngine
{
    interface IRuleEngine
    {
       void GetDiscountedPrice(List<ProductDto> productList);
    }

}
