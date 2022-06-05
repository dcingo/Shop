using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using Shop.Application.Common.Exceptions;
using System;

namespace Shop.Application.SalePoints.Commands.DeleteSalePoint
{
    public class DeleteSalePointsCommandHandler : IRequestHandler<DaeleteSalePointCommand>
    {
        private readonly IShopDbContext _DbContext;

        public DeleteSalePointsCommandHandler(IShopDbContext dbContext)
        {
            _DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Unit> Handle(DaeleteSalePointCommand request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.SalesPoints.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Buyer), request.Id);
            }
            _DbContext.SalesPoints.Remove(entity);
            await _DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
