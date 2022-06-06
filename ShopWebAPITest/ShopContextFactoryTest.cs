using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using Shop.Persistence;


namespace ShopWebAPITest
{
    public class ShopContextFactoryTest
    {
        public static ShopDbContext Create()
        {

            var opt = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ShopDbContext(opt);
            context.Database.EnsureCreated();
            Product t1 = new Product { Name = "Товар 1", Price = 50.5 };
            Product t2 = new Product { Name = "Товар 2", Price = 30.1 };
            Product t3 = new Product { Name = "Товар 3", Price = 20.2 };
            Product t4 = new Product { Name = "Товар 4", Price = 10.0 };
            context.Products.Add(t1);
            context.Products.Add(t2);
            context.Products.Add(t3);
            context.Products.Add(t4);
            context.SaveChanges();
            ProvidedProduct pp11 = new ProvidedProduct { Product = t1, ProductQuantity = 100 };
            ProvidedProduct pp12 = new ProvidedProduct { Product = t2, ProductQuantity = 80 };
            ProvidedProduct pp23 = new ProvidedProduct { Product = t3, ProductQuantity = 70 };
            ProvidedProduct pp24 = new ProvidedProduct { Product = t4, ProductQuantity = 150 };
            ProvidedProduct pp32 = new ProvidedProduct { Product = t2, ProductQuantity = 120 };
            ProvidedProduct pp34 = new ProvidedProduct { Product = t4, ProductQuantity = 140 };
            SalesPoint sp1 = new SalesPoint { Name = "Магазин 1", ProvidedProducts = new List<ProvidedProduct> { pp11, pp12 } };
            SalesPoint sp2 = new SalesPoint { Name = "Магазин 2", ProvidedProducts = new List<ProvidedProduct> { pp23, pp24 } };
            SalesPoint sp3 = new SalesPoint { Name = "Магазин 3", ProvidedProducts = new List<ProvidedProduct> { pp32, pp34 } };
            context.SalesPoints.Add(sp1);
            context.SalesPoints.Add(sp2);
            context.SalesPoints.Add(sp3);
            context.SaveChanges();
            Buyer b1 = new Buyer() { Name = "Покупатель 1", salesId = "" };
            Buyer b2 = new Buyer() { Name = "Покупатель 2", salesId = "" };
            Buyer b3 = new Buyer() { Name = "Покупатель 3", salesId = "" };
            context.Buyers.Add(b1);
            context.Buyers.Add(b2);
            context.Buyers.Add(b3);
            context.SaveChanges();
            Sale s = new Sale
            {
                Buyer = b1,
                Date = DateTime.Now,
                Time = DateTime.Now,
                SalesData = new List<SaleData> { new SaleData { product = t1, ProductQuantity = 10, ProductIdAmount = t1.Price * 10 },
                            new SaleData {product =t2, ProductQuantity =20, ProductIdAmount =t2.Price*20 }},
                SalesPoint = sp1,
                TotalAmount = t1.Price * 10 + t2.Price * 20
            };
            context.Sales.Add(s);
            context.SaveChanges();
            b1.salesId += s.Id;
            context.SaveChanges();
            return context;
        }

        public static void Destroy(ShopDbContext shopDbContext)
        {
            shopDbContext.Database.EnsureDeleted();
            shopDbContext.Dispose();
        }

    }
}
