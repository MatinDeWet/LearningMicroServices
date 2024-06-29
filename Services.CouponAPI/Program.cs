using Microsoft.EntityFrameworkCore;
using Services.CouponAPI;
using Services.CouponAPI.Data.Contexts;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.RegisterContext(RegisterExtensions.ConfigureDbContextForMsSql(builder.Configuration.GetConnectionString("CouponDb")!));

        builder.Services.RegisterAutoMapper();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        MaintainDatabase(app);

        app.Run();
    }

    private static void MaintainDatabase(IApplicationBuilder app)
    {
        using(var scope = app.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<CouponContext>();

            if (context.Database.GetPendingMigrations().Count() > 0)
            {
                context.Database.Migrate();
            }
        }
    }
}
