using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain;
using Shop.Application.Interfaces;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;

namespace Shop.Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, int>
    {
        private readonly IShopDbContext _DbContext;

        public CreateSaleCommandHandler(IShopDbContext dbContext)=>
            _DbContext = dbContext;
        public async Task<int> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            Buyer buyer = _DbContext.Buyers.FirstOrDefault(x=>x.Id==request.Buyer);
            SalesPoint sp = _DbContext.SalesPoints.Include(pp=>pp.ProvidedProducts).FirstOrDefault(x=>x.Id==request.SalesPoint);
            if (sp == null) throw new NotFoundException("Точка продажи не найдена",cancellationToken);
            List<SaleData> list = new();
            foreach (var x in request.SaleDatas)
            {
                Product product = _DbContext.Products.FirstOrDefault(prod => prod.Id == x.IdProduct);
                if(product == null) throw new NotFoundException("Продукта не существует", cancellationToken);
                ProvidedProduct prProd = sp.ProvidedProducts.FirstOrDefault(prod => prod.Id == x.IdProduct && prod.ProductQuantity > x.count);
                if (prProd == null)
                    throw new NotFoundException("Продукт отсутсвует в точке продаже", cancellationToken);
                list.Add(new() { product = product, ProductQuantity = x.count,ProductIdAmount =product.Price* x.count, productid=product.Id });
                prProd.ProductQuantity -= x.count;
            }
            var sale = new Sale
            {
                Buyer = buyer,
                Date = DateTime.Now,
                SalesPoint = sp,
                SalesData = list,
                Time = DateTime.Now,
                TotalAmount = list.Sum(x => x.ProductIdAmount)
            };

            await _DbContext.Sales.AddAsync(sale, cancellationToken);
            await _DbContext.SaveChangesAsync(cancellationToken);
            if (buyer != null)
            {
                buyer.Sales.Add(sale);
                if (buyer.salesId == "")
                {
                    buyer.salesId += sale.Id;
                }
                else
                {
                    buyer.salesId +=","+ sale.Id;
                }
            }
            await _DbContext.SaveChangesAsync(cancellationToken);
            return sale.Id;
        }
    }
}
