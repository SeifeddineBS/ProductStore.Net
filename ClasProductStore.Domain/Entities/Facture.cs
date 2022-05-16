using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductStore.Domain.Entities
{
    public class Facture
    {
        public DateTime DateAchat { get; set; }
        public double Prix { get; set; }
        //prop de navigation
        [ForeignKey("ClientFk")]
        public virtual Client Client { get; set; }

        [ForeignKey("ProductFK")]
        public virtual Product Product { get; set; }

        public int ProductFK { get; set; }

        public int ClientFk { get; set; }
    }
}
