using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; } //– дата осуществления продажи
        public DateTime Time { get; set; } //– время осуществления продажи
        [Required]
        public SalesPoint SalesPoint { get; set; }// – идентификатор точки продажи
        public Buyer Buyer { get ; set; }//– идентификатор покупателя(Can by null)
        public List<SaleData> SalesData { get; set; } = new();
        public double TotalAmount { get; set; }//– общая сумма всей покупки
    }
}
