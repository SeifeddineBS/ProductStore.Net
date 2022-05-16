using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Service.TP1_StoreManagement
{
    public static class MyExtension
    {


        public static string ToUpper(this ProductManagement pm , string value)
        {
            return value.ToUpper();

        }

        public static string ToLower(this ProviderManagement pv , string value)
        {
            return value.ToLower();
        
        }

        public static bool InCategory(this ProductManagement pm , Product p , string CatName)
        {
            return p.Category.Name.Equals(CatName);

        }

    }
}
