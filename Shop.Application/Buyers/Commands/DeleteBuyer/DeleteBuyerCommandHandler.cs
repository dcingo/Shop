using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using Shop.Application.Common.Exceptions;

namespace Shop.Application.Buyers.Commands.DeleteBuyer
{
    public class DeleteBuyerCommandHandler : IRequestHandler<DeleteBuyerCommand>
    {


        private readonly IShopDbContext _DbContext;

        public DeleteBuyerCommandHandler(IShopDbContext dbContext) =>
            _DbContext = dbContext;

        public async Task<Unit> Handle(DeleteBuyerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Buyers
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Buyer), request.Id);
            }
            _DbContext.Buyers.Remove(entity);
            await _DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
