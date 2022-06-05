using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;

namespace Shop.Application.SalePoints.Commands.UpdateSalePoint
{
    public class UpdateSalePointCommandHandler : IRequestHandler<UpdateSalePointCommand>
    {
        private readonly IShopDbContext _DbContext;

        public UpdateSalePointCommandHandler(IShopDbContext dbContext)
        {
            _DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<Unit> Handle(UpdateSalePointCommand request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.SalesPoints.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }
            entity.Name = request.Name;
            entity.ProvidedProducts = new();
            foreach(var x in request.ProvidedProduct)
            {
                Product product = _DbContext.Products.FirstOrDefault(y => y.Id == x.ProductId);
                if (product != null)
                {
                    entity.ProvidedProducts.Add(new ProvidedProduct() { Product = product, ProductQuantity = x.count, SalesPoint = entity });
                }
            }
            await _DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
