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

namespace Shop.Application.SalePoints.Queries.GetSalePointDetails
{
    public class GetSalePointsQueryHandler :
        IRequestHandler<GetSalePointDetailsQuery, SalePointDetailsVm>
    {
        private readonly IShopDbContext _DbContext;
        private readonly IMapper _Mapper;

        public GetSalePointsQueryHandler(IShopDbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SalePointDetailsVm> Handle(GetSalePointDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.SalesPoints.Include(psr => psr.ProvidedProducts)
                .FirstOrDefaultAsync(sale => sale.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }
            return _Mapper.Map<SalePointDetailsVm>(entity);
        }
    }
} 
