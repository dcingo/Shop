using System;
using System.Collections.Generic;
using MediatR;
using Shop.Domain;


namespace Shop.Application.Sales.Commands.UpdateSale
{
    public class UpdateSaleCommand:IRequest
    {
        public int Id { get; set; }
        public SalesPoint SalesPoint { get; set; }
        public Buyer Buyer { get; set; }
        public List<SaleData> SalesData { get; set; }

    }
}
