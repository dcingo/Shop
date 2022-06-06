using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Shop.Application.Interfaces;
using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Shop.Domain;

namespace Shop.Application.Sales.Queries.GetSaleList
{
    public class GetBuyerListQueryHandler : IRequestHandler<GetSaleListQuery, SaleListVm>
    {

        private readonly IShopDbContext _DbContext;
        private readonly IMapper _Mapper;
        public GetBuyerListQueryHandler(IShopDbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
        }

        public async Task<SaleListVm> Handle(GetSaleListQuery request, CancellationToken cancellationToken)
        {
            var salesQuery = await _DbContext.Sales.Include(p => p.Buyer)
                .Include(s => s.SalesPoint)
                .Include(sd => sd.SalesData)
                .ProjectTo<SaleLookupDto>(_Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);/**/
            return new SaleListVm { Sales = salesQuery };
        }
    }
}
