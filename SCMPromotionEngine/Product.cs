using System;
using System.Collections.Generic;
using System.Text;

namespace SCMPromotionEngine
{
    class Product
    {
        public Char SKU { get; set; }
        public int OrderedQty { get; set; }
        public int BulkDiscountMinQty { get; set; }
        public int DiscountPercent { get; set; }
        public int Price { get; set; }
        public int SubTotal { get; set; }
    }
}
