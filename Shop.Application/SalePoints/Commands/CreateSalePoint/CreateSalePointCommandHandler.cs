using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using System.Collections.Generic;

namespace Shop.Application.SalePoints.Commands.CreateSalePoint
{
    public class CreateSalePointCommandHandler : IRequestHandler<CreateSalePointCommands, int>
    {
        private readonly IShopDbContext _DbContext;

        public CreateSalePointCommandHandler(IShopDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<int> Handle(CreateSalePointCommands request, CancellationToken cancellationToken)
        {

            List<ProvidedProduct> ProvProduct = new List<ProvidedProduct>();
            SalesPoint salePoint = new() { Name =request.Name, ProvidedProducts =ProvProduct };
            foreach(var x in request.ProvidedProduct)
            {
                Product product = _DbContext.Products.FirstOrDefault(y => y.Id == x.ProductId);
                if (product!= null)
                {
                    ProvProduct.Add(new() { Product = product, ProductQuantity = x.count, SalesPoint = salePoint });
                }
            }

            _DbContext.SalesPoints.Add(salePoint);
            await _DbContext.SaveChangesAsync(cancellationToken);

            return salePoint.Id;
        }

    }
}
