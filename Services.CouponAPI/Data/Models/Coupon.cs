namespace Services.CouponAPI.Data.Models
{
    public partial class Coupon
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }
    }
}
