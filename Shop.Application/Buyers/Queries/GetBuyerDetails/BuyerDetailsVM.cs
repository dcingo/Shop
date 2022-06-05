using System;
using System.Collections.Generic;
using AutoMapper;
using Shop.Domain;
using Shop.Application.Common.Mappings;


namespace Shop.Application.Buyers.Queries.GetBuyerDetails
{
    public class BuyerDetailsVM : IMapWith<Buyer>
    {
        public int Id { get; set; }// – Идентификатор
        public string Name { get; set; }// – Название
        public List<Sale> Sales { get; set; } = new();//– коллекция всех идентификаторов покупок/. бред
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Buyer, BuyerDetailsVM>()
                .ForMember(buyerVM => buyerVM.Id, opt => opt.MapFrom(buyer => buyer.Id))
                .ForMember(buyerVM => buyerVM.Name, opt => opt.MapFrom(buyer => buyer.Name))
                .ForMember(buyerVM => buyerVM.Sales, opt => opt.MapFrom(buyer => buyer.Sales));
        }
    }
}