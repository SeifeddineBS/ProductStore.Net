using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductStore.Domain.Entities
{
    public class Client
    {
        [Key]
        public int CIN { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Email { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public virtual IList<Facture> Factures { get; set; }
    }
}
