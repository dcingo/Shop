using System;
using System.Collections.Generic;
using AutoMapper;
using Shop.Domain;
using Shop.Application.Common.Mappings;


namespace Shop.Application.Sales.Queries.GetSaleDetails
{
    public class SaleDetailsVM : IMapWith<Sale>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public DateTime Time { get; set; } 
        public SalesPoint SalesPointId { get; set; }
        public Buyer BuyerId { get; set; }
        public List<SaleData> SalesData { get; set; }
        public double TotalAmount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Sale, SaleDetailsVM>()
                .ForMember(saleVM => saleVM.Id, opt => opt.MapFrom(sale => sale.Id))
                .ForMember(saleVM => saleVM.Date, opt => opt.MapFrom(sale => sale.Date))
                .ForMember(saleVM => saleVM.Time, opt => opt.MapFrom(sale => sale.Time))
                .ForMember(saleVM => saleVM.SalesPointId, opt => opt.MapFrom(sale => sale.SalesPoint))
                .ForMember(saleVM => saleVM.BuyerId, opt => opt.MapFrom(sale => sale.Buyer))
                .ForMember(saleVM => saleVM.SalesData, opt => opt.MapFrom(sale => sale.SalesData))
                .ForMember(saleVM => saleVM.TotalAmount, opt => opt.MapFrom(sale => sale.TotalAmount));
        }
    }
}