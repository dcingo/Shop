using Shop.Domain;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Shop.Application.Interfaces
{
    public interface IShopDbContext
    {
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesPoint> SalesPoints { get; set; }
        public DbSet<SaleData> SaleDatas { get; set; }
        public DbSet<ProvidedProduct> ProvidedProducts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
