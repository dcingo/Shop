using AutoMapper;
using Shop.Application.Buyers.Commands.UpdateBuyer;
using Shop.Application.Common.Mappings;
using Shop.Domain;
using System.Collections.Generic;

namespace Shop.WebAPI.Models
{
    public class UpdateBuyerDto : IMapWith<UpdateBuyerCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sale> Sales { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBuyerDto, UpdateBuyerCommand>()
                .ForMember(buyerComand => buyerComand.Id, opt => opt.MapFrom(buyerDto => buyerDto.Id))
                .ForMember(buyerComand => buyerComand.Name, opt => opt.MapFrom(buyerDto => buyerDto.Name));
        }
    }
}
