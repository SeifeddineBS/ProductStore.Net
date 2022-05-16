using ProductStore.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Service
{
    public interface IProductService :IService<Product>
    {
        IEnumerable<Product> GetProductsByCategoryName(string CatName);

        
    }
}
