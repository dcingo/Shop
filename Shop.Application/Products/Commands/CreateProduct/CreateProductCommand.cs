using MediatR;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }

        public double Price { get; set; }  
    }

}
