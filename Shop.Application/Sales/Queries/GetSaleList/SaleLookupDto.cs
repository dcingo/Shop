using Shop.Domain;
using AutoMapper;
using Shop.Application.Common.Mappings;
using System;
using System.Collections.Generic;

namespace Shop.Application.Sales.Queries.GetSaleList
{
    public class SaleLookupDto:IMapWith<Sale>
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public SalesPoint SalesPoint { get; set; }
        public Buyer Buyer { get; set; }
        public List<SaleData> SalesData { get; set; }
        public double TotalAmount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sale, SaleLookupDto>()
                .ForMember(saleVM => saleVM.Id, opt => opt.MapFrom(sale => sale.Id))
                .ForMember(saleVM => saleVM.Date, opt => opt.MapFrom(sale => sale.Date))
                .ForMember(saleVM => saleVM.Time, opt => opt.MapFrom(sale => sale.Time))
                .ForMember(saleVM => saleVM.SalesPoint, opt => opt.MapFrom(sale => sale.SalesPoint))
                .ForMember(saleVM => saleVM.Buyer, opt => opt.MapFrom(sale => sale.Buyer))
                .ForMember(saleVM => saleVM.SalesData, opt => opt.MapFrom(sale => sale.SalesData))
                .ForMember(saleVM => saleVM.TotalAmount, opt => opt.MapFrom(sale => sale.TotalAmount));
        }
    }
}
