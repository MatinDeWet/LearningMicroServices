using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.CouponAPI.Data.Models;

namespace Services.CouponAPI.Data.Configurations
{
    public partial class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        partial void OnConfigurePartial(EntityTypeBuilder<Coupon> entity)
        {
            entity.HasData(GenerateSeedData());
        }

        private static Coupon[] GenerateSeedData()
        {
            var result = new List<Coupon>();

            result.Add(new Coupon
            {
                Id = 1,
                Code = "10OFF",
                DiscountAmount = 10,
                MinAmount = 20
            });

            result.Add(new Coupon
            {
                Id = 2,
                Code = "20OFF",
                DiscountAmount = 20,
                MinAmount = 40
            });

            return result.ToArray();
        }
    }
}
