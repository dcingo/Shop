using Shop.Application.Common.Mappings;
using Shop.Application.SalePoints.Commands.CreateSalePoint;
using AutoMapper;
using System;
using System.Collections.Generic;
using Shop.Domain;


namespace Shop.WebAPI.Models
{
    public class CreateSalePointsDto:IMapWith<CreateSalePointCommands>
    {
        public string Name { get; set; }
        public List<DataProvidedProduct> ProvidedProduct { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSalePointsDto, CreateSalePointCommands>()
                .ForMember(salePointComand => salePointComand.Name, opt => opt.MapFrom(salePointDto => salePointDto.Name))
                .ForMember(salePointComand => salePointComand.ProvidedProduct, opt => opt.MapFrom(salePointDto => salePointDto.ProvidedProduct));
        }
    }
}
