using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain
{
    public class SaleData
    {
        [Key]
        public int Id { get; set; }

        public int productid { get; set; }
        public Product  product { get; set; }//– идентификатор купленного продукта
        public int ProductQuantity { get; set; }//– количество штук купленных продуктов данного ProductId
        public double ProductIdAmount { get; set; }//– общая стоимость купленного количества товаров данного ProductId
    }
}
