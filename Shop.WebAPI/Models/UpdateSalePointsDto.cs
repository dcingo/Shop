using Shop.Application.Common.Mappings;
using Shop.Application.SalePoints.Commands.UpdateSalePoint;
using AutoMapper;
using System;
using System.Collections.Generic;
using Shop.Domain;

namespace Shop.WebAPI.Models
{
    public class UpdateSalePointsDto: IMapWith<UpdateSalePointCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProvidedProduct> ProvidedProduct { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSalePointsDto, UpdateSalePointCommand>()
                .ForMember(salePointComand => salePointComand.Id, opt => opt.MapFrom(salePointDto => salePointDto.Id))
                .ForMember(salePointComand => salePointComand.Name, opt => opt.MapFrom(salePointDto => salePointDto.Name))
                .ForMember(salePointComand => salePointComand.ProvidedProduct, opt => opt.MapFrom(salePointDto => salePointDto.ProvidedProduct));
        }

    }
}
