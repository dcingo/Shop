using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SalePoints.Commands.UpdateSalePoint
{
    public class UpdateSalePointCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DataProvidedProduct> ProvidedProduct { get; set; }
    }

    public class DataProvidedProduct
    {
        public int ProductId { get; set; }
        public int count { get; set; }
    }
}
