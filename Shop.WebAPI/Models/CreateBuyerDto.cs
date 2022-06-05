using AutoMapper;
using Shop.Application.Buyers.Commands.CreateBuyer;
using Shop.Application.Common.Mappings;

namespace Shop.WebAPI.Models
{
    public class CreateBuyerDto : IMapWith<CreateBuyerCommand>
    {
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBuyerDto, CreateBuyerCommand>()
                .ForMember(saleComand => saleComand.Name, opt => opt.MapFrom(buyerDto => buyerDto.Name));
        }
    }
}
