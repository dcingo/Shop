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

namespace Shop.Application.Buyers.Queries.GetBuyerList
{
    public class GetBuyerListAueryHandler : IRequestHandler<GetBuyerListQuery, BuyerListVm>
    {

        private readonly IShopDbContext _DbContext;
        private readonly IMapper _Mapper;
        public GetBuyerListAueryHandler(IShopDbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
        }

        public async Task<BuyerListVm> Handle(GetBuyerListQuery request, CancellationToken cancellationToken)
        {
            var BuersQuery = await _DbContext.Buyers.Include(c=>c.Sales)
                .ProjectTo<BuyerLookupDto>(_Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);/**/
            return new BuyerListVm { Buyers = BuersQuery };
        }
    }
}
