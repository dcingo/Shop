using System;
using MediatR;

namespace Shop.Application.Buyers.Queries.GetBuyerDetails
{
    public class GetBuyerDetailsQuery:IRequest<BuyerDetailsVM>
    {
        public int Id { get; set; }
    }
}
