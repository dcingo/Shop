using Shop.Domain;
using AutoMapper;
using Shop.Application.Common.Mappings;
using System;
using System.Collections.Generic;


namespace Shop.Application.SalePoints.Queries.GetSalePointList
{
    public class SalePointLookupDto:IMapWith<SalesPoint>
    {
        public int Id { get; set; }// – Идентификатор
        public string Name { get; set; }
        public List<ProvidedProduct> ProvidedProducts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SalesPoint, SalePointLookupDto>()
                .ForMember(SpVM => SpVM.Id, opt => opt.MapFrom(Sp => Sp.Id))
                .ForMember(SpVM => SpVM.Name, opt => opt.MapFrom(Sp => Sp.Name))
                .ForMember(SpVM => SpVM.ProvidedProducts, opt => opt.MapFrom(Sp => Sp.ProvidedProducts));
        }
    }
}
