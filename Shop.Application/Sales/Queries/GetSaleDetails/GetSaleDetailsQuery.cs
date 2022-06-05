using System;
using MediatR;

namespace Shop.Application.Sales.Queries.GetSaleDetails
{
    public class GetSaleDetailsQuery:IRequest<SaleDetailsVM>
    {
        public int Id { get; set; }
    }
}
