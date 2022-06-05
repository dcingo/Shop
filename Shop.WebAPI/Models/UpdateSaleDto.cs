using Shop.Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using Shop.Domain;
using Shop.Application.Sales.Commands.UpdateSale;

namespace Shop.WebAPI.Models
{
    public class UpdateSaleDto:IMapWith<UpdateSaleCommand>
    {
        public int Id { get; set; }   
        public int SalesPoint { get; set; }
        public int Buyer { get; set; }
        public List<SaleData> SalesData { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSaleDto, UpdateSaleCommand>()
                .ForMember(saleComand => saleComand.Id, opt => opt.MapFrom(saleDto => saleDto.Id))
                .ForMember(saleComand => saleComand.Buyer, opt => opt.MapFrom(saleDto => saleDto.Buyer))
                .ForMember(saleComand => saleComand.SalesPoint, opt => opt.MapFrom(saleDto => saleDto.SalesPoint))
                .ForMember(saleComand => saleComand.SalesData, opt => opt.MapFrom(saleDto => saleDto.SalesData));
        }
    }
}
