using System;
using System.Collections.Generic;
using AutoMapper;
using Shop.Domain;
using Shop.Application.Common.Mappings;


namespace Shop.Application.Products.Queries.GetProductDetails
{
    public class ProductDetailsVM : IMapWith<Product>
    {
        public int Id { get; set; }// – Идентификатор
        public string Name { get; set; }// – Название
        public double Price { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailsVM>()
                .ForMember(buyerVM => buyerVM.Id, opt => opt.MapFrom(buyer => buyer.Id))
                .ForMember(buyerVM => buyerVM.Name, opt => opt.MapFrom(buyer => buyer.Name))
                .ForMember(buyerVM => buyerVM.Price, opt => opt.MapFrom(buyer => buyer.Price));
        }
    }
}