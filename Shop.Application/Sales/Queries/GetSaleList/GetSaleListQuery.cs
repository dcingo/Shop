using System;
using MediatR;

namespace Shop.Application.Sales.Queries.GetSaleList
{
    public class GetSaleListQuery:IRequest<SaleListVm>
    {
        public int Id { get; set; }
    }
}
