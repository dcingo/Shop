using System;
using System.Collections.Generic;
using AutoMapper;
using Shop.Domain;
using Shop.Application.Common.Mappings;


namespace Shop.Application.SalePoints.Queries.GetSalePointDetails
{
    public class SalePointDetailsVm : IMapWith<SalesPoint>
    {
        public int Id { get; set; }// – Идентификатор
        public string Name { get; set; }
        public List<ProvidedProduct> ProvidedProducts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SalesPoint, SalePointDetailsVm>()
                .ForMember(SpVM => SpVM.Id, opt => opt.MapFrom(Sp => Sp.Id))
                .ForMember(SpVM => SpVM.Name, opt => opt.MapFrom(Sp => Sp.Name))
                .ForMember(SpVM => SpVM.ProvidedProducts, opt => opt.MapFrom(Sp => Sp.ProvidedProducts));
        }

    }
}
