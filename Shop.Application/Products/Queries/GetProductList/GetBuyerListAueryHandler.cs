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

namespace Shop.Application.Products.Queries.GetProductList
{
    public class GetBuyerListAueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
    {

        private readonly IShopDbContext _DbContext;
        private readonly IMapper _Mapper;
        public GetBuyerListAueryHandler(IShopDbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
        }

        public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var BuersQuery = await _DbContext.Products
                .ProjectTo<ProductLookupDto>(_Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);/**/
            return new ProductListVm { Products = BuersQuery };
        }
    }
}
