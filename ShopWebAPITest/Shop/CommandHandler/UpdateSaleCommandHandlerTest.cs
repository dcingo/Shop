using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shop.Application.Sales.Commands.UpdateSale;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;



namespace ShopWebAPITest.Shop.CommandHandler
{
    public class UpdateSaleCommandHandlerTest : CommandDbTest
    {
        [Fact]
        public async Task UpdateSaleCommandHandler_CanExecute()
        {         //Arrange
            var handler = new UpdateSaleCommandHandler(_contextTest);
            var userid = 2;
            var salePointId = 2;
            var Id = 1;
            //Act
            var saleID = await handler.Handle(
                new UpdateSaleCommand
                {
                    BuyerId = userid,
                    SalesPointId = salePointId,
                    Id = Id

                }, CancellationToken.None);
            //Assert
            Assert.NotNull(
                await _contextTest.Sales.SingleOrDefaultAsync(sale =>
                    sale.Id == Id && sale.Buyer.Id == userid && sale.SalesPoint.Id == salePointId));

        }

        [Fact]
        public async Task UpdateSaleCommandHandler_FailOnWrongId()
        {
            //Arranre
            var handler = new UpdateSaleCommandHandler(_contextTest);
            int Id = 10;
            var userid = 2;
            var salePointId = 2;
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(
                new UpdateSaleCommand
                {
                    BuyerId = userid,
                    SalesPointId = salePointId,
                    Id = Id

                }, CancellationToken.None));
        }

    }
}
