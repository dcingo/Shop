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
        public int SalesPointId { get; set; }
        public int BuyerId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSaleDto, UpdateSaleCommand>()
                .ForMember(saleComand => saleComand.Id, opt => opt.MapFrom(saleDto => saleDto.Id))
                .ForMember(saleComand => saleComand.BuyerId, opt => opt.MapFrom(saleDto => saleDto.BuyerId))
                .ForMember(saleComand => saleComand.SalesPointId, opt => opt.MapFrom(saleDto => saleDto.SalesPointId));
        }
    }
}
