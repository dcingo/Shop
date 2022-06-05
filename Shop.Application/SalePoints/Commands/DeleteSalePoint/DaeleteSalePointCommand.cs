using MediatR;

namespace Shop.Application.SalePoints.Commands.DeleteSalePoint
{
    public class DaeleteSalePointCommand : IRequest
    {
        public int Id { get; set; }
    }
}
