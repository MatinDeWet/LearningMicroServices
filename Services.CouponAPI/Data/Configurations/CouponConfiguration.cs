using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.CouponAPI.Data.Models;

namespace Services.CouponAPI.Data.Configurations
{
    public partial class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable(nameof(Coupon));

            entity.HasIndex(e => e.Code);

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.DiscountAmount)
                .IsRequired();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Coupon> entity);
    }
}
