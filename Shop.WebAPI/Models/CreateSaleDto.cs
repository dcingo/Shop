using Shop.Application.Common.Mappings;
using Shop.Application.Sales.Commands.CreateSale;
using AutoMapper;
using System;
using System.Collections.Generic;
using Shop.Domain;

namespace Shop.WebAPI.Models
{
    public class CreateSaleDto:IMapWith<CreateSaleCommand>
    {
        public int SalesPoint { get; set; }
        public int Buyer { get; set; }
        public List<QuerySaleData> SaleDatas { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSaleDto, CreateSaleCommand>()
                .ForMember(saleComand => saleComand.BuyerId, opt => opt.MapFrom(saleDto => saleDto.Buyer))
                .ForMember(saleComand => saleComand.SalesPointId, opt => opt.MapFrom(saleDto => saleDto.SalesPoint))
                .ForMember(saleComand => saleComand.SaleDatas, opt => opt.MapFrom(saleDto => saleDto.SaleDatas));
        }
    }
}
