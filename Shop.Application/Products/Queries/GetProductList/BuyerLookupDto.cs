using Shop.Domain;
using AutoMapper;
using Shop.Application.Common.Mappings;
using System;
using System.Collections.Generic;

namespace Shop.Application.Products.Queries.GetProductList
{
    public class ProductLookupDto : IMapWith<Product>
    {

        public int Id { get; set; }// – Идентификатор
        public string Name { get; set; }// – Название
        public double Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductLookupDto>()
                .ForMember(buyerVM => buyerVM.Id, opt => opt.MapFrom(buyer => buyer.Id))
                .ForMember(buyerVM => buyerVM.Name, opt => opt.MapFrom(buyer => buyer.Name))
                .ForMember(buyerVM => buyerVM.Price, opt => opt.MapFrom(buyer => buyer.Price));
        }
    }
}
