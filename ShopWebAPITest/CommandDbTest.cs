using System;
using Shop.Persistence;

namespace ShopWebAPITest
{
    public abstract class CommandDbTest:IDisposable
    {
        protected readonly ShopDbContext _contextTest;

        public CommandDbTest()
        {
            _contextTest = ShopContextFactoryTest.Create();
        }

        public void Dispose()
        {
            ShopContextFactoryTest.Destroy(_contextTest);
        }
    }
}
