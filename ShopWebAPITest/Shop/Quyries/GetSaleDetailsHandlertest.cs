using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Sales.Queries.GetSaleDetails;
using Xunit;
using Shop.Persistence;
using AutoMapper;
using Shop.Application.Common.Exceptions;

namespace ShopWebAPITest.Shop.Quyries
{
    public class GetSaleDetailsHandlertest
    {
        private readonly ShopDbContext Context;
        private readonly IMapper Mapper;

        public GetSaleDetailsHandlertest(QueryTestFixtute fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }


        [Fact]
        public async void GetSaleDetailsQueryHandeler_Success()
        {
            //Arrange
            var handler = new GetBuyerDetailsQueryHandler(Context, Mapper);
            //Act
            var list = await handler.Handle(new GetSaleDetailsQuery { Id = 1 }, CancellationToken.None);
            //Assert
            Assert.NotNull(list);

        }

        [Fact]
        public async void GetSaleDetailsQueryHandeler_WrongID()
        {
            //Arrange
            var handler = new GetBuyerDetailsQueryHandler(Context, Mapper);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(
                new GetSaleDetailsQuery
                {
                    Id = 10
                }, CancellationToken.None));
        }
    }
}
