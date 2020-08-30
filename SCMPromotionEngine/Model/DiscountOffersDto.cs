namespace SCMPromotionEngine
{
    public class DiscountOffersDto
    {
        public int OfferGroupId { get; set; }
        public int ProductId { get; set; }
        public string OfferType { get; set; }
        public string DiscountType { get; set; }
        public int MinimumDiscountQty { get; set; }
        public double DiscountValue { get; set; }
    }
}
