using MediatR;
using Shop.Domain;
using System.Collections.Generic;

namespace Shop.Application.SalePoints.Commands.CreateSalePoint
{
    public class CreateSalePointCommands: IRequest<int>
    {
        public string Name { get; set; }
        public List<DataProvidedProduct> ProvidedProduct { get; set; }
    }


    public class DataProvidedProduct
    {
        public int ProductId { get; set; }
        public int count { get; set; }
    }
}
