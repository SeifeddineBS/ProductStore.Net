using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductStore.Service.TP1_StoreManagement
{
    public class ProductManagement
    {


        //ctor +2 tab

        List<Product> myProducts = new List<Product>();
        public ProductManagement(List<Product> products)
        {
            myProducts = products;
        }



        public IEnumerable<Chemical> Get5ChemicalByPrice(double price)
        {
            //linq
            //var query = from p in myProducts.OfType<Chemical>()
            //            where p.Price > price
            //            select p;
            //return query.Take(5);



            // lambda 

            return myProducts.OfType<Chemical>().Where(p => p.Price > price).Take(5);
        }



        public IEnumerable<Product> GetProductsByPrice(double price)
        {
            // linq 

            //var query = from p in myProducts
            //            where p.Price > price
            //            select p;
            //return query.Skip(2);


            // lambda

            return myProducts.Where(p => p.Price > price).Skip(2);

        }

        public double GetAveragePrice()
        {
            // linq
            /* return (from m in myProducts
                     select m.Price).Average();*/


            //lambda 
            return myProducts.Select(p => p.Price).Average();
            // return myProducts.Average(p => p.Price);

        }

        public Product GetProductByMaxPrice()
        {
            double max = (from m in myProducts
                          select m.Price).Max();
            return (from p in myProducts
                    where p.Price == max
                    select p).First();


            //lambda
            //return myProducts.OrderBy(p => p.Price).LastOrDefault();
            //return myProducts.OrderByDescending(p => p.Price).FirstOrDefault();
            //return myProducts.OrderBy(p => p.Price).Reverse().FirstOrDefault();


        }

        public int GetCountChemicalByCity(string city)
        {
            //lambda 

            return myProducts.OfType<Chemical>().Where(p => p.Address.City.Equals(city)).Count();

        }

        public IEnumerable<Chemical> GetChemicalsByCity()
        {
            //lambda

            //  return myProducts.OfType<Chemical>().OrderBy(p => p.City);


            //linq
            return (from p in myProducts.OfType<Chemical>()
                    orderby p.Address.City
                    select p);

        }

        public IGrouping<string, IEnumerable<Chemical>> GetChemicalsGroupByCity()
        {
            //lambda
            /// return (IGrouping<string, IEnumerable<Chemical>>)
            /// myProducts.OfType<Chemical>().OrderBy(p => p.City).GroupBy(p => p.City);
            //linq
            return ((IGrouping<string, IEnumerable<Chemical>>)
                (from p in myProducts.OfType<Chemical>()
                 orderby p.Address.City
                 group p by p.Address.City));

        }

        // POUR LE TEST
        public void diplay()
        {
            var result =
                (from p in myProducts.OfType<Chemical>()
                 orderby p.Address.City descending
                 group p by p.Address.City);

            foreach (var ProductByCity in result)
            {
                Console.WriteLine(" city =  " + ProductByCity.Key); // key = city
                foreach (var chemical in ProductByCity)
                {
                    Console.WriteLine("les produits" + chemical.Name);

                }
            }

        }

    } 

        
       



    
}
