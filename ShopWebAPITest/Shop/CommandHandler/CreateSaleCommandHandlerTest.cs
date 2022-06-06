using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shop.Application.Sales.Commands.CreateSale;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;

namespace ShopWebAPITest.Shop.CommandHandler
{
    public class CreateSaleCommandHandlerTest : CommandDbTest
    {
        [Fact]
        public async Task CreateSaleCommandHandler_Execute()
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
        public async Task CreateSaleCommandHandler_ExecuteBuyerNull()
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
                sale.Id == saleID && sale.Buyer == null && sale.SalesPoint.Id == salePointId));

        }
        [Fact]
        public async Task CreateSaleCommandHandler_ExecuteSalePoint()
        {
            //Arrange
            var handler = new CreateSaleCommandHandler(_contextTest);
            var userid = 0;
            var salePointId = 2;
            var dateset = new List<QuerySaleData>() { new() { IdProduct = 1, count = 10 }, new() { IdProduct = 4, count = 30 } };
            //act
            //assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(
              new CreateSaleCommand
              {
                  BuyerId = userid,
                  SalesPointId = salePointId,
                  SaleDatas = dateset
              }, CancellationToken.None));

        }
        [Fact]
        public async Task CreateSaleCommandHandler_ExecuteSalePointWrong()
        {
            //Arrange
            var handler = new CreateSaleCommandHandler(_contextTest);
            var userid = 2;
            var salePointId = 10;
            var dateset = new List<QuerySaleData>() { new() { IdProduct = 3, count = 10 }, new() { IdProduct = 4, count = 30 } };
            //act
            //assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(
              new CreateSaleCommand
              {
                  BuyerId = userid,
                  SalesPointId = salePointId,
                  SaleDatas = dateset
              }, CancellationToken.None));

        }

        [Fact]
        public async Task CreateSaleCommandHandler_ExecuteProductWrong()
        {
            //Arrange
            var handler = new CreateSaleCommandHandler(_contextTest);
            var userid = 2;
            var salePointId = 2;
            var dateset = new List<QuerySaleData>() { new() { IdProduct = 3, count = 1000 }, new() { IdProduct = 4, count = 30 } };
            //act
            //assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(
              new CreateSaleCommand
              {
                  BuyerId = userid,
                  SalesPointId = salePointId,
                  SaleDatas = dateset
              }, CancellationToken.None));

        }
    }
}
