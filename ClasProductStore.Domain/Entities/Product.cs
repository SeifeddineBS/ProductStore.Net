using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductStore.Domain.Entities
{
    //internal class Product : elle n'est visible que dans le projet Domain

    public class Product :Concept
    {
        //ctor+2tab
        public Product()
        {

        }
        public Product(DateTime productionDate, string description, string name, double price, int productId, int quantity)
        {
            ProductionDate = productionDate;
            Description = description;
            Name = name;
            Price = price;
            ProductId = productId;
            Quantity = quantity;
        }
        #region type prop
        //private string name;
        //public string GetName()
        //{
        //    return name;
        //}
        // public void SetName (string value)
        //{
        //    name = value;
        //}
        //*******prop + double tab :light version****** 

        //public string Name { get; set; }

        ////******propg + double tab : secure version *****
        ///
        //public int MyProperty { get; private set; }

        ////****propfull + double tab : full version ****
        //private int myVar;

        //public int MyProperty2
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}

        #endregion

        //prop de base
        [DataType(DataType.Date)]
        [Display(Name = "Production Date")]
        public DateTime ProductionDate { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "field is required!")]
        [StringLength(25, ErrorMessage = "user input 25!")]
        [MaxLength(50, ErrorMessage = "storage max 50!")]

        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string ImageURL2 { get; set; }
        public int? CateoryId { get; set; } //? champs nullabe un produit peut avoir 0 catégorie

        public PackagingType PType { get; set; }
        //prop de navigation
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual IList<Provider> Providers { get; set; }
        public virtual IList<Facture> Factures { get; set; }
        public override string GetDetails()
        {
            return " Quantity :" + Quantity+ " \n  Name :" + Name+ "\n Price : " + Price;
        }


        public virtual string GetMyType()
        {
            return "UNKNOWN";
        }
    }

}
