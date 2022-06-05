using System;
using MediatR;

namespace Shop.Application.SalePoints.Queries.GetSalePointList
{
    public class GetSalePointsListQuery : IRequest<SalePointListVm>
    {
        public int Id { get; set; }
    }
}
