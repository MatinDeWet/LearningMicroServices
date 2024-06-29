using Microsoft.EntityFrameworkCore;
using Services.CouponAPI.Data.Models;

namespace Services.CouponAPI.Data.Contexts
{
    public class CouponContext : DbContext
    {
        public CouponContext(DbContextOptions<CouponContext> options) : base(options)
        {
        }

        public virtual DbSet<Coupon> Coupons { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(CouponContext).Assembly);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
