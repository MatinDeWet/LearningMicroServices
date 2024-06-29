using Microsoft.EntityFrameworkCore;
using Services.CouponAPI.Data.Contexts;
using System.Reflection;

namespace Services.CouponAPI
{
    public static class RegisterExtensions
    {
        public static void RegisterContext(this IServiceCollection services, Action<DbContextOptionsBuilder> configureContext)
        {
            services.AddDbContext<CouponContext>(configureContext);
        }

        public static Action<DbContextOptionsBuilder> ConfigureDbContextForMsSql(string connectionstring)
        {
            var migrationAssembly = typeof(CouponContext).GetTypeInfo().Assembly.GetName().Name;

            return (DbContextOptionsBuilder options) =>
            {
                options.UseSqlServer(connectionstring, opt => opt.MigrationsAssembly(migrationAssembly));
            };
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(RegisterExtensions).Assembly);
        }
    }
}
