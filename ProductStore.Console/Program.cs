


using Microsoft.Extensions.DependencyInjection;
using ProductStore.Data;
using ProductStore.Data.Infrastructures;
using ProductStore.Domain.Entities;
using ProductStore.Service;
using ProductStore.Service.TP1_StoreManagement;
using System;
using System.Collections.Generic;

namespace ProductStore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            #region Tp1
            //******** test de la méthode GetDetails()
            Product prod = new Product
            {
                Quantity = 15,
                Name = "produit",
                Price = 1500
            };
            //cwl + 2 tab
            System.Console.WriteLine("les détails du produit \n : " + prod.GetDetails());

            //****** test de la méthode (a) ****//
            Provider p = new Provider
            {
                UserName = "ines",
                Password = "123456789",
                ConfirmPassword = "123456789",
                Email = "ines@esprit.tn",

                IsApproved = false
            };


            ProviderManagement provManagement = new ProviderManagement();
            //cwl + 2 tab
            System.Console.WriteLine("ancienne valeur = " + p.IsApproved);

            provManagement.SetIsApproved(p);

            //****** test de la methode (b)*****//
            //initialiseur d'un objet
            //Provider pi = new Provider
            //{

            //    Password = "12",
            //    ConfirmPassword = "123",

            //};


            //provManagement.SetIsApproved(pi.Password, pi.ConfirmPassword);
            System.Console.WriteLine("nouvelle valeur de isApproved = " + p.IsApproved);

            //forçage de la méthode (b)
            //string x = pi.ConfirmPassword;

            //provManagement.SetIsApproved(pi1.Password,  ref x);



            //Login
            //  System.Console.WriteLine("Login = " + provManagement.Login("ines", "123456789", p));
            //      System.Console.WriteLine("Login = " + provManagement.Login(p.UserName,p.Password,p.Email,p));



            /****/

            //initialiseur d'objet
            Product prod2 = new Product { 
                Price = 100,
                Name = "newProd" ,
                Category = new Category
                {
                   Name="CategorieProd2"
                }

                
            };
            Chemical chem = new Chemical {

                Address = new Address
                {
                    StreetAddress = "Chotrana "
                },
                Name = "MyChemical product" };

            Chemical chem2 = new Chemical
            {

                Address = new Address
                {
                    StreetAddress = "Chotrana "
                },
                Name = "MyChemical product"
            };
            //Constructeur 


            System.Console.WriteLine(" le Produit est de type"+prod2.GetMyType());
            System.Console.WriteLine("le produit est de type:"+chem.GetMyType());
            #endregion
            #region Test Question 10 (scénario)

            Provider PROV1 = new Provider
            {

                Id = 2,
                UserName = "Provider1",
              
                Email = "prod1@esprit.tn",

            };


            Provider PROV2 = new Provider
            {
                UserName = "prod2",

                Email = "prod2@esprit.tn",

                Id=3



            };

            Provider PROV3 = new Provider
            {
                UserName = "provider3",
                Email = "provider3@esprit.tn",





            };


            Provider PROV4 = new Provider
            {
                UserName = "provider4",
                Email = "provider4@esprit.tn",




            };
            Provider PROV5 = new Provider
            {
                UserName = "provider5",
                Email = "provider5@esprit.tn",





            };
            Category CAT1 = new Category {
                Name = "Cat1"

            };
            Category CAT2 = new Category
            {
                Name = "Cat2"
            };
            Category CAT3 = new Category
            {
                Name = "Cat3"
            };


            Product PROD1 = new Product
            {
                Name="PROD1",
                Category=CAT1,

                Providers= new List<Provider>()
                {
                    PROV1,PROV2,PROV3
                }
            };



            Product PROD2 = new Product
            {
                Name = "PROD2",
                Category = CAT1,

                Providers = new List<Provider>()
                {
                    PROV1
                }
            };



            Product PROD3 = new Product
            {
                Name = "PROD3",
                Category = CAT3,

                Providers = new List<Provider>()
                {
                    PROV1
                }
            };

            Product PROD4 = new Product
            {
                Name = "PROD4",
                Category = null,

                Providers = new List<Provider>()
                {
                    PROV3,PROV4,PROV5
                }
            };

            Product PROD5 = new Product
            {
                Name = "prod5",
                Category = CAT2,

                Providers = new List<Provider>()
                {
                  
                }
            };

            Product PROD6 = new Product
            {
                Name = "PROD6",
                Category = CAT3,

                Providers = new List<Provider>()
                {
                    PROV4,PROV5
                }
            };
            CAT1.Products = new List<Product> {
                PROD1,PROD2
            };
            CAT2.Products = new List<Product> {
                PROD5
            };


            CAT3.Products = new List<Product> {
                PROD3, PROD6
            };

            PROV1.Products = new List<Product> { PROD1, PROD2, PROD3 };
            PROV2.Products = new List<Product> { PROD1, PROD5 };
            PROV3.Products = new List<Product> { PROD1 };
            PROV4.Products = new List<Product> { PROD1, PROD6 };
            PROV5.Products = new List<Product> { PROD6, PROD4 };

             System.Console.WriteLine( "***************");

            PROV1.GetProducts("Name", "PROD3");


            #endregion
            #region Lambda et Linq
            System.Console.WriteLine("************Debut****************");
            System.Console.WriteLine("Le provider"
                +provManagement.GetProviderById(2,new List<Provider> {PROV1,PROV2}).GetDetails());
            System.Console.WriteLine("************Fin****************");

            Chemical chem3 = new Chemical
            {

                Name = "chem3",
                Description = "bad",

                Address = new Address
                {
                    City = "Ariana",
                    StreetAddress = "Ghazela"
                },
               Price = 15,
               Quantity =1000
            

            };

            Chemical chem4 = new Chemical
            {
                Address = new Address
                {
                    City = "BenArous",
                    StreetAddress = "Rades"
                },
                Name = "chem4",
                Description = "good",
               
                Price = 10,
                Quantity = 1000


            };

            Chemical chem5 = new Chemical
            {

                Name = "chem5",
                Description = "good",

                Address = new Address
                {
                    City = "Ariana",
                    StreetAddress = "Rades"
                },

                Price = 10,
                Quantity = 1000


            };


            List<Product> products = new List<Product> { 
                chem3,chem4 , chem5
            };
            ProductManagement pm = new ProductManagement(products);
            foreach (var cc in pm.Get5ChemicalByPrice(2))
            {
                System.Console.WriteLine("le produit =" +cc.Name+ "Prix= "+cc.Price );
            }

            System.Console.WriteLine
                ("le nombre de produit par city=" +pm.GetCountChemicalByCity("Ariana"));


            pm.diplay();

            System.Console.WriteLine("le nom du produit 5= " +pm.ToUpper(PROD5.Name));

            #endregion

            #region Génération de la base de donnée
            //instanciation d'un nouveau objet :produit
            Product p1 = new Product
            {
                Name = "p1",
                Category = new Category
                {
                    Name = "CategorieProd2"
                }


            };
            //création de la base de donnée
            PSContext context = new PSContext();// il va implicitement appeler la m DatabaseEnsure Created

            context.Products.Add(p1);
            context.Products.Add(prod2);
            context.Chemicals.Add(chem5);
                // ajout du produit P1 au dbset
            context.SaveChanges(); // synchronisation de la base

            #endregion
            #region chargement de données 
            foreach (Product MyProduct in context.Products)
            {
                System.Console.WriteLine("Product = "+MyProduct.Name/* +"Category = " +MyProduct.Category.Name*/);
                if (MyProduct.Category!=null)
                    System.Console.WriteLine("Category = "+MyProduct.Category.Name);
               
            }


            #endregion
            #region Design Pattern
            var serviceProvider = new ServiceCollection()
                .AddScoped<IProductService, ProductService>()
                .AddTransient<IUnitOfWork, UnitOfWork>()

                .AddSingleton<IDataBaseFactory, DataBaseFactory>()
                .BuildServiceProvider();

            var ps = serviceProvider.GetService<IProductService>();
            ps.Add(p1);
            System.Console.WriteLine("Product added!");
                

            #endregion



        }







    }
}
