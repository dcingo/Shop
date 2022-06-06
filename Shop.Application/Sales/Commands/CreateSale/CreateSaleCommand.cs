using System;
using System.Collections.Generic;
using MediatR;
using Shop.Domain;

namespace Shop.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : IRequest<int>
    {
        public int SalesPointId { get; set; }
        public int BuyerId { get; set; }
        public List<QuerySaleData> SaleDatas { get; set; }
    }

    public class QuerySaleData
    {
        public int IdProduct { get; set; }
        public int count { get; set; }
    }

}
