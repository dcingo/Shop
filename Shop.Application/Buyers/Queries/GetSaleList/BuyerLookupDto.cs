using Shop.Domain;
using AutoMapper;
using Shop.Application.Common.Mappings;
using System;
using System.Collections.Generic;

namespace Shop.Application.Buyers.Queries.GetBuyerList
{
    public class BuyerLookupDto:IMapWith<Sale>
    {

        public int Id { get; set; }// – Идентификатор
        public string Name { get; set; }// – Название
        public List<Sale> Sales { get; set; } = new();//– коллекция всех идентификаторов покупок/. бред
       // public List<int> ListidSale { get; set; } = new();
       public string salesId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Buyer, BuyerLookupDto>()
                .ForMember(buyerVM => buyerVM.Id, opt => opt.MapFrom(buyer => buyer.Id))
                .ForMember(buyerVM => buyerVM.Name, opt => opt.MapFrom(buyer => buyer.Name))
                .ForMember(buyerVM => buyerVM.salesId, opt => opt.MapFrom(buyer => buyer.salesId))
                .ForMember(buyerVM => buyerVM.Sales, opt => opt.MapFrom(buyer => buyer.Sales));
        }
    }
}
