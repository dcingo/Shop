using System;
using System.Collections.Generic;
using MediatR;
using Shop.Domain;

namespace Shop.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : IRequest<int>
    {
        public int SalesPoint { get; set; }
        public int Buyer { get; set; }
        public List<querySaleData> SaleDatas { get; set; }
    }

    public class querySaleData
    {
        public int IdProduct { get; set; }
        public int count { get; set; }
    }

}
