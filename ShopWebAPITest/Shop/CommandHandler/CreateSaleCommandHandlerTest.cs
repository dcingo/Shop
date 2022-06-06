using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shop.Application.Sales.Commands.CreateSale;
using Microsoft.EntityFrameworkCore;

namespace ShopWebAPITest.Shop.CommandHandler
{
    public class CreateSaleCommandHandlerTest : CommandDbTest
    {
        [Fact]
        public async Task Can_create_sale()
        {
            //Arrange
            var handler =new CreateSaleCommandHandler(_contextTest);
            var userid = 2;
            var salePointId = 2;
            var dateset = new List<QuerySaleData>() { new() { IdProduct = 3, count = 10 }, new() { IdProduct = 4, count = 30 } };

            //Act
            var saleID = await handler.Handle(
                new CreateSaleCommand
                {
                    BuyerId = userid,
                    SalesPointId = salePointId,
                    SaleDatas = dateset

                }, CancellationToken.None);
            //Assert
            Assert.NotNull(
                await _contextTest.Sales.SingleOrDefaultAsync(sale =>
                sale.Id == saleID && sale.Buyer.Id == userid && sale.SalesPoint.Id == salePointId));

        }

        [Fact]
        public async Task Can_create_sale_Buer_null()
        {
            //Arrange
            var handler = new CreateSaleCommandHandler(_contextTest);
            var userid = 0;
            var salePointId = 2;
            var dateset = new List<QuerySaleData>() { new() { IdProduct = 3, count = 10 }, new() { IdProduct = 4, count = 30 } };

            //Act
            var saleID = await handler.Handle(
                new CreateSaleCommand
                {
                    BuyerId = userid,
                    SalesPointId = salePointId,
                    SaleDatas = dateset

                }, CancellationToken.None);
            //Assert
            Assert.NotNull(
                await _contextTest.Sales.SingleOrDefaultAsync(sale =>
                sale.Id == saleID && sale.Buyer.Id == userid && sale.SalesPoint.Id == salePointId));

        }
    }
}
