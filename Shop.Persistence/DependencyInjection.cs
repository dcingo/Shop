using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<SalesDbContext>(options =>
            {
                //options.UseInMemoryDatabase("dbSale");
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IShopDbContext>(options =>
                options.GetService<SalesDbContext>());
            return services;
        }
    }
}
