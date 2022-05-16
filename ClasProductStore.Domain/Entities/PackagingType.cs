using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductStore.Domain.Entities
{
  public  enum PackagingType
    {
        [Display (Name = "Carton")]
        carton = 0,
        [Display(Name = "Plastic")]
        plastic =1
    }
}
