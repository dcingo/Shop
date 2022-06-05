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

namespace Shop.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler :
        IRequestHandler<GetProductDetailsQuery, ProductDetailsVM>
    {

        private readonly IShopDbContext _DbContext;
        private readonly IMapper _Mapper;
        public GetProductDetailsQueryHandler(IShopDbContext dbContext,IMapper mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
        }


        public async Task<ProductDetailsVM> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Products
                .FirstOrDefaultAsync(sale => sale.Id == request.Id, cancellationToken);


            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
            return _Mapper.Map<ProductDetailsVM>(entity);
        }
    }
}
