using System;
using MediatR;

namespace Shop.Application.Buyers.Queries.GetBuyerList
{
    public class GetBuyerListQuery:IRequest<BuyerListVm>
    {
        public int Id { get; set; }
    }
}
