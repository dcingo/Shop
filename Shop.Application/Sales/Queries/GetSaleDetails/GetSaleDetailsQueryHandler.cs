using System;
using System.Collections.Generic;
using System.Linq;
using Shop.Domain;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Shop.Application.Sales.Queries.GetSaleDetails
{
    public class GetBuyerDetailsQueryHandler :
        IRequestHandler<GetSaleDetailsQuery, SaleDetailsVM>
    {

        private readonly IShopDbContext _DbContext;
        private readonly IMapper _Mapper;
        public GetBuyerDetailsQueryHandler(IShopDbContext dbContext,IMapper mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
        }


        public async Task<SaleDetailsVM> Handle(GetSaleDetailsQuery request, CancellationToken cancellationToken)
        {
            var salesQuery = await _DbContext.Sales.Include(p => p.Buyer)
                        .Include(s => s.SalesPoint)
                        .Include(sd => sd.SalesData)
                        .ProjectTo<SaleDetailsVM>(_Mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync(sale => sale.Id == request.Id, cancellationToken);

            if (salesQuery == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }
            return _Mapper.Map<SaleDetailsVM>(salesQuery);
        }
    }
}
