using AutoMapper;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Common.Mappings;

namespace Shop.WebAPI.Models
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>()
                .ForMember(productComand => productComand.Name, opt => opt.MapFrom(productDto => productDto.Name))
                .ForMember(productComand => productComand.Price, opt => opt.MapFrom(productDto => productDto.Price));
        }
    }
}
