using System;
using System.Collections.Generic;
using MediatR;
using Shop.Domain;


namespace Shop.Application.Sales.Commands.UpdateSale
{
    public class UpdateSaleCommand:IRequest
    {
        public int Id { get; set; }
        public int SalesPointId { get; set; }
        public int BuyerId { get; set; }
        
    }
}
