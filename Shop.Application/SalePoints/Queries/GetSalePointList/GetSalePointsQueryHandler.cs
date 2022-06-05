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


namespace Shop.Application.SalePoints.Queries.GetSalePointList
{
    public class GetSalePointsQueryHandler: IRequestHandler<GetSalePointsListQuery, SalePointListVm>
    {
        private readonly IShopDbContext _DbContext;
        private readonly IMapper _Mapper;

        public GetSalePointsQueryHandler(IShopDbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SalePointListVm> Handle(GetSalePointsListQuery request, CancellationToken cancellationToken)
        {
            var SalePointsQuery = await _DbContext.SalesPoints
                .ProjectTo<SalePointLookupDto>(_Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);/**/
            return new SalePointListVm {  SalePoints = SalePointsQuery };
        }
    }
}
