using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using System.Collections.Generic;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IShopDbContext _DbContext;

        public CreateProductCommandHandler(IShopDbContext dbContext)=>
            _DbContext = dbContext;
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product prod = new() { Name = request.Name , Price = request.Price};
            _DbContext.Products.Add(prod);
            await _DbContext.SaveChangesAsync(cancellationToken);

            return prod.Id;
        }
    }
}
