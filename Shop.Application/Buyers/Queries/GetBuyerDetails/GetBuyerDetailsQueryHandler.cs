﻿using System;
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

namespace Shop.Application.Buyers.Queries.GetBuyerDetails
{
    public class GetBuyerDetailsQueryHandler :
        IRequestHandler<GetBuyerDetailsQuery, BuyerDetailsVM>
    {

        private readonly IShopDbContext _DbContext;
        private readonly IMapper _Mapper;
        public GetBuyerDetailsQueryHandler(IShopDbContext dbContext,IMapper mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
        }


        public async Task<BuyerDetailsVM> Handle(GetBuyerDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Sales.Include(b => b.Buyer).Include(s => s.SalesPoint).Include(sd => sd.SalesData)
                .FirstOrDefaultAsync(sale => sale.Id == request.Id, cancellationToken);

            
            String s=  entity.Buyer.Name;

            if (entity == null)
            {
                throw new NotFoundException(nameof(Sale), request.Id);
            }
            return _Mapper.Map<BuyerDetailsVM>(entity);
        }
    }
}
