using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using Shop.Application.Common.Exceptions;

namespace Shop.Application.Sales.Commands.DeleteSale
{
    public class DeleteBuyerCommandHandler : IRequestHandler<DeleteSaleCommand>
    {


        private readonly IShopDbContext _DbContext;

        public DeleteBuyerCommandHandler(IShopDbContext dbContext) =>
            _DbContext = dbContext;

        public async Task<Unit> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Sales
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }
            _DbContext.Sales.Remove(entity);
            await _DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
