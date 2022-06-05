using System.Collections.Generic;


namespace Shop.Application.Products.Queries.GetProductList
{
    public class ProductListVm
    {
        public IList<ProductLookupDto> Products { get; set; }
    }
}
