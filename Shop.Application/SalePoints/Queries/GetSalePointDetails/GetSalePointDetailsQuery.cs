using MediatR;


namespace Shop.Application.SalePoints.Queries.GetSalePointDetails
{
    public class GetSalePointDetailsQuery : IRequest<SalePointDetailsVm>
    {
        public int Id { get; set; }
    }
}
