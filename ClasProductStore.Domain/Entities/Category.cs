using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Domain.Entities
{
   public class Category
    {
        //prop de base
        public int CategoryId { get; set; }
        public string Name { get; set; }
        //prop de navigation
        public virtual IList<Product> Products { get; set; }

       
    }
}
