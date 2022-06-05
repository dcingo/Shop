using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;

namespace Shop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {

        private readonly IShopDbContext _DbContext;

        public UpdateProductCommandHandler(IShopDbContext dbContext) =>
            _DbContext = dbContext;

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Products.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }
            entity.Name = request.Name;
            entity.Price = request.Price;
            await _DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
