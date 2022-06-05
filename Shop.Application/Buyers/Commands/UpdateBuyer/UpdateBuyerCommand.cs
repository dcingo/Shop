using System;
using System.Collections.Generic;
using MediatR;
using Shop.Domain;


namespace Shop.Application.Buyers.Commands.UpdateBuyer
{
    public class UpdateBuyerCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sale> Sales { get; set; }

    }
}
