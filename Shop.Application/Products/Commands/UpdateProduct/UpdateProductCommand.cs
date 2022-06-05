using System;
using System.Collections.Generic;
using MediatR;
using Shop.Domain;


namespace Shop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
