using System;
using MediatR;

namespace Shop.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
        public int Id { get; set; }
    }
}
