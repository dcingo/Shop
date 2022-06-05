using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }// – Идентификатор
        public string Name { get; set; }// – Название
        public double Price { get; set; }// – стоимость
    }
}
