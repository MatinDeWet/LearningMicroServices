namespace Services.CouponAPI.Data.Dtos
{
    public class CouponDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;

        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }
    }
}
