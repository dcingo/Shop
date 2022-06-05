using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain
{
    public class ProvidedProduct
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }// – идентификатор продукта
        public SalesPoint SalesPoint { get; set; }
        public int ProductQuantity { get; set; }// – количество
    }
}
