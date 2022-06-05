using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;

namespace Shop.Application.Buyers.Commands.UpdateBuyer
{
    public class UpdateBuyerCommandHandler : IRequestHandler<UpdateBuyerCommand>
    {

        private readonly IShopDbContext _DbContext;

        public UpdateBuyerCommandHandler(IShopDbContext dbContext) =>
            _DbContext = dbContext;

        public async Task<Unit> Handle(UpdateBuyerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Buyers.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }
            entity.Name = request.Name;
            entity.Sales = request.Sales;
            await _DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
