using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Domain
{
    public class Buyer
    {
        [Key]
        public int Id { get; set; }// – Идентификатор
        public string Name { get; set; }// – Название

       
        public List<Sale> Sales { get; set; } = new();//– коллекция всех идентификаторов покупок/. бред
        /*[NotMapped]
         public int[] Data
        {
            get
            {
                string[] tab = this.InternalData.Split(',');
                return new int[] { int.Parse(tab[0]), int.Parse(tab[1]) };
            }
            set
            {
                this.InternalData = string.Format("{0},{1}", value[0], value[1]);
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InternalData { get; set; }*/
    }
}
