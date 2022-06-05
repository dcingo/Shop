using AutoMapper;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.Application.Common.Mappings;
using Shop.Domain;
using System.Collections.Generic;

namespace Shop.WebAPI.Models
{
    public class UpdateProductDto : IMapWith<UpdateProductCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
                .ForMember(productComand => productComand.Id, opt => opt.MapFrom(productDto => productDto.Id))
                .ForMember(productComand => productComand.Name, opt => opt.MapFrom(productDto => productDto.Name))
                .ForMember(productComand => productComand.Price, opt => opt.MapFrom(productDto => productDto.Price));
        }
    }
}
