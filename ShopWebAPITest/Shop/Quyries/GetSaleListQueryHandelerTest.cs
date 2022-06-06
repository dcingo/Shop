using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Shop.Application.Sales.Queries.GetSaleList;
using Xunit;
using Shop.Application.Sales.Queries.GetSaleList;
using Shop.Persistence;
using AutoMapper;

namespace ShopWebAPITest.Shop.Quyries
{
    public class GetSaleListQueryHandelerTest
    {
        private readonly ShopDbContext Context;
        private readonly IMapper Mapper;

        public GetSaleListQueryHandelerTest(QueryTestFixtute fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }


        [Fact]
        public async void GetSaleListQueryHandeler_Success()
        {
            //Arrange
            var handler = new GetBuyerListQueryHandler(Context,Mapper);
            //Act
            var list = await handler.Handle(new GetSaleListQuery { Id = 0},CancellationToken.None);
            //Assert
            Assert.NotNull(list);

        }

    }
}
