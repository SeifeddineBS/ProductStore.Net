using ProductStore.Data;
using ProductStore.Data.Infrastructures;
using ProductStore.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductStore.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        //PSContext mycontext = new PSContext();
        public ProductService(IUnitOfWork utk) : base(utk)
        {
        }

        public IEnumerable<Product> GetProductsByCategoryName(string CatName)
        {
            return GetMany(p => p.Category.Name.Contains(CatName));


        }
    }
}
