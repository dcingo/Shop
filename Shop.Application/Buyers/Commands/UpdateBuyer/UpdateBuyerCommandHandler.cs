using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using System.Collections.Generic;

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

            List < Sale> salelist = new();
            string d = "";
            string[] ss = request.salesId.Split(",");
            if (ss.Length > 1)
            {
                foreach (var x in ss)
                {
                    Sale s = _DbContext.Sales.FirstOrDefault(sale => sale.Id == Int32.Parse(x));
                    if (s == null) continue;
                    salelist.Add(s);
                    if (d == "")
                    {
                        d += s.Id;
                    }
                    else
                    {
                        d += "," + s.Id;
                    }
                }
            }
            else
            {
                salelist.Add(_DbContext.Sales.FirstOrDefault(sale => sale.Id == Int32.Parse(request.salesId)));
                d = request.salesId;
            }
            entity.Sales = salelist;
            entity.salesId = d; 
            entity.Name = request.Name;
            await _DbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
       
        }
    }
}
