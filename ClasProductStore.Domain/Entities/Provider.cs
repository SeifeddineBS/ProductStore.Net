using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductStore.Domain.Entities
{
    public class Provider:Concept
    {
        //prop de base
        [NotMapped]
        [Required(ErrorMessage = "Confirm password is required!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        //private string myConfirmPass;
        //public string ConfirmPassword
        //{
        //    get { return myConfirmPass; }
        //    set
        //    {
        //        if (value.Equals(Password))
        //            myConfirmPass = value;
        //        else { throw new Exception("Confirmation failed !"); }
        //    }
        //}
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
        //private string password;

        //public string Password
        //{
        //    get { return password; }
        //    set { if (value.Length >= 5 && value.Length<= 20)
        //        password = value;
        //        else Console.WriteLine("password doit avoir une taille dans l'intervalle [5,20]");
        //                }
        //}

       
        public DateTime DateCreated { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Key]
        public int Id { get; set; }
        public bool IsApproved { get; set; } 

        public string UserName { get; set; }

       


        //prop de navigation

        public virtual IList<Product> Products { get; set; }


        public override string GetDetails()
        {
            string ProviderDetails = "\n Provider : UserName = \n" + UserName + "\n Email" + Email; 
            foreach (Product p in Products)
            {
                ProviderDetails += "\n Product : " + p.GetDetails();
            }

            return ProviderDetails;
        }



        public void GetProducts(string filterType, string filterValue)
        {
            switch (filterType.ToLower())
            {
                case "dateprod":
                    foreach (Product prod in Products)
                    {
                        if (prod.ProductionDate.Equals(filterValue))
                            Console.WriteLine(prod.GetDetails());
                    }

                    break;
                case "name":
                    foreach (Product prod in Products)
                    {
                        if (prod.Name.Equals(filterValue))
                            Console.WriteLine(prod.GetDetails());
                    }
                    break;

                case "Category":
                    foreach (Product prod in Products)
                    {
                        if (prod.Category.Equals(filterValue))
                            Console.WriteLine(prod.GetDetails());
                    }
                    break;
            }
        }


    }
}
