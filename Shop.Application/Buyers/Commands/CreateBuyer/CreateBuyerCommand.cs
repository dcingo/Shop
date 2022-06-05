using MediatR;

namespace Shop.Application.Buyers.Commands.CreateBuyer
{
    public class CreateBuyerCommand : IRequest<int>
    {
        public string Name { get; set; }// – Название
    }

}
