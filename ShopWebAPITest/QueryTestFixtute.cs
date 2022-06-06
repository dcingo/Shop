using AutoMapper;
using Shop.Persistence;
using System;
using Shop.Application.Interfaces;
using Shop.Application.Common.Mappings;
using Xunit;

namespace ShopWebAPITest
{
    public class QueryTestFixtute:IDisposable
    {
        public ShopDbContext Context;
        public IMapper Mapper;

        public QueryTestFixtute()
        {
            Context = ShopContextFactoryTest.Create();
            var conProvider = new MapperConfiguration(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(typeof(IShopDbContext).Assembly));
            });
            Mapper = conProvider.CreateMapper();

        }


        public void Dispose()
        {
            ShopContextFactoryTest.Destroy(Context);
        }

        [CollectionDefinition("QueryCoollection")]
        public class QueryCoollection : ICollectionFixture<QueryCoollection> { }
    }
}
