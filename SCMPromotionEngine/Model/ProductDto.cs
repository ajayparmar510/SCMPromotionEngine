namespace SCMPromotionEngine
{
    public class ProductDto
    {
        public int ProductId;
        public string SKU { get; set; }
        public int OrderedQty { get; set; }
        public double ProductPrice { get; set; }
        public string OfferType { get; set; }
        public int? OfferGroupId { get; set; }
        public double SubTotal { get; set; }
    }
}
