using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shop.Application.Sales.Commands.DeleteSale;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;

namespace ShopWebAPITest.Shop.CommandHandler
{
    public class DeletSaleCommandHandlerTest : CommandDbTest
    {
        [Fact]
        public async Task DeletSaleCommandHandler_CanExecute()
        {
            //Arranre
            var handler = new DeleteSaleCommandHandler(_contextTest);
            int saleId = 1;
            //Act
            var sale = await handler.Handle(
                new DeleteSaleCommand
                {
                     Id = saleId
                }, CancellationToken.None);
            //Assert
            Assert.Null(
                await _contextTest.Sales.SingleOrDefaultAsync(sale => sale.Id == saleId));
        }


        [Fact]
        public async Task DeletSaleCommandHandler_FailOnWrongId()
        {
            //Arranre
            var handler = new DeleteSaleCommandHandler(_contextTest);
            int saleId = 10;
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>( async () => await handler.Handle(
                new DeleteSaleCommand
                {
                    Id= saleId
                }, CancellationToken.None));           
        }
    }
}
