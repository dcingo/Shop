using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Domain
{
    public class SalesPoint
    {
        [Key]
        public int Id { get; set; }// – Идентификатор
        public string Name { get; set; }// – Название
        public List<ProvidedProduct> ProvidedProducts { get; set; } = new();// – список сущностей
    }
}
