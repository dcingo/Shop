using System;
using MediatR;

namespace Shop.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery:IRequest<ProductDetailsVM>
    {
        public int Id { get; set; }
    }
}
