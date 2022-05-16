using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Domain.Entities
{
    public class Biological:Product
    {
        public string Herbs { get; set; }

       
        public override string GetDetails()
        {
            return base.GetDetails()+"Herbs = "+ Herbs;
        }

        public override string GetMyType()
        {
            return "Biological";
        }

    }
  
}
