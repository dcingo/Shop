using System;
using MediatR;

namespace Shop.Application.Sales.Commands.DeleteSale
{
    public class DeleteSaleCommand:IRequest
    {
        public int Id { get; set; }
    }
}
