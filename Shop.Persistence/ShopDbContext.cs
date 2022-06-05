using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain;
using Shop.Persistence.EntityTypeConfiguration;


namespace Shop.Persistence
{
    public class SalesDbContext : DbContext, IShopDbContext
    {
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesPoint> SalesPoints { get; set; }
        public DbSet<SaleData> SaleDatas { get; set; }
        public DbSet<ProvidedProduct> ProvidedProducts { get; set; }
        public SalesDbContext(DbContextOptions<SalesDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SaleConfiguration());
            builder.ApplyConfiguration(new BuyerConfiguration());
            builder.ApplyConfiguration(new SalesPointConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProvidedProductsConfiguration());
            builder.ApplyConfiguration(new SaleDatasConfiguration());
            base.OnModelCreating(builder);
        }
    }
}

