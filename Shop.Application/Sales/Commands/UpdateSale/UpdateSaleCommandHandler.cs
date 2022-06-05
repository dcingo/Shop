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
    public class UpdateBuyerCommandHandler : IRequestHandler<UpdateSaleCommand>
    {

        private readonly IShopDbContext _DbContext;

        public UpdateBuyerCommandHandler(IShopDbContext dbContext) =>
            _DbContext = dbContext;

        public async Task<Unit> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Sales.FirstOrDefaultAsync(sale => sale.Id == request.Id, cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }
            entity.SalesData = request.SalesData;
            entity.SalesPoint = request.SalesPoint;
            entity.Date =  DateTime.Now;
            entity.Time = DateTime.Now;
            entity.Buyer = request.Buyer;
            entity.TotalAmount = request.SalesData.Sum(x => x.ProductIdAmount);
            await _DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
