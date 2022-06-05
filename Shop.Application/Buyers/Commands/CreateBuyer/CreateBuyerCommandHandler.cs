using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using System.Collections.Generic;

namespace Shop.Application.Buyers.Commands.CreateBuyer
{
    public class CreateBuyerCommandHandler : IRequestHandler<CreateBuyerCommand, int>
    {
        private readonly IShopDbContext _DbContext;

        public CreateBuyerCommandHandler(IShopDbContext dbContext)=>
            _DbContext = dbContext;
        public async Task<int> Handle(CreateBuyerCommand request, CancellationToken cancellationToken)
        {
            Buyer buyer = new() { Name = request.Name , Sales = new()};
            _DbContext.Buyers.Add(buyer);
            await _DbContext.SaveChangesAsync(cancellationToken);

            return buyer.Id;
        }
    }
}
