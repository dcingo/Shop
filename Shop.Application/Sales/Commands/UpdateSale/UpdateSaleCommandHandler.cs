using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;

namespace Shop.Application.Sales.Commands.UpdateSale
{
    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand>
    {

        private readonly IShopDbContext _DbContext;

        public UpdateSaleCommandHandler(IShopDbContext dbContext) =>
            _DbContext = dbContext;

        public async Task<Unit> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Sales.FirstOrDefaultAsync(sale => sale.Id == request.Id, cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }
            var salePoint = await _DbContext.SalesPoints.FirstOrDefaultAsync(sp=>sp.Id == request.SalesPointId, cancellationToken);
            if (salePoint == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }
            var buyer = await _DbContext.Buyers.FirstOrDefaultAsync(b => b.Id == request.BuyerId, cancellationToken);
            if (salePoint == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }
            entity.SalesPoint = salePoint;
            entity.Date =  DateTime.Now;
            entity.Time = DateTime.Now;
            entity.Buyer = buyer;
            await _DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
