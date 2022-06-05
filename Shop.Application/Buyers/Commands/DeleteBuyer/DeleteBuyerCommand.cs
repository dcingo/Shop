using System;
using MediatR;

namespace Shop.Application.Buyers.Commands.DeleteBuyer
{
    public class DeleteBuyerCommand:IRequest
    {
        public int Id { get; set; }
    }
}
