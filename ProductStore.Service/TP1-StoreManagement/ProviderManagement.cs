using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductStore.Service.TP1_StoreManagement
{
    public class ProviderManagement
    {
        public void SetIsApproved(Provider P)
        {
            if (P.ConfirmPassword.Equals(P.Password))
                P.IsApproved = true;
            else P.IsApproved = false;
        }
        //exemples
        public bool SetIsApproved2(Provider P)
        {
            if (P.Password.CompareTo(P.ConfirmPassword) == 0) return true;
            else return false;
        }

        public bool SetIsApproved3(Provider P)
        {
            return P.Password.CompareTo(P.ConfirmPassword) == 0;
        }


        ///***//
        // méthode b
        public bool SetIsApproved(string password,  /*ref*/ string confirmPassword)
        {
            return password.CompareTo(confirmPassword) == 0;
         }

        //public bool SetIsApproved(string password, string confirmPassword,bool IsApproved)
        //{
        //    return IsApproved = password.CompareTo(confirmPassword) == 0;        }

        public bool Autorisation(string nom, string mdp, IList<Provider> maliste)
        {
            foreach (Provider p in maliste)
            {
                if (p.UserName.Equals(nom) && p.Password.Equals(mdp))
                    return true;
            }
            return false;
        }

        public bool Login(string nom, string mdp, Provider p)
        {
            if (p.UserName.Equals(nom) && p.Password.Equals(mdp))
                return true;
            return false;
        }

        public bool Login(string nom, string mdp, string email, Provider p)
        {
            if (Login(nom, mdp, p) && p.Email.Equals(email))
                return true;
            return false;
        }

        public bool Login(string nom, string mdp, Provider p,string email= null)
        {
            if (Login(nom, mdp, p) && (email != null ? p.Email == email : true))
                return true;
            return false;

            



        }


        public IEnumerable<Provider> GetProvidersByName(string name, List<Provider> Myproviders)
        {
            //List<Provider> result = new List<Provider>();

            //foreach (Provider p in Myproviders)
            //{
            //    if (p.UserName.Contains(name))
            //        result.Add(p);             

            //}
            //return result.AsEnumerable();
            // linq
            var query = from p in Myproviders
                        where p.UserName.Contains(name)
                        select p;
            return query.AsEnumerable();


        }

        public Provider GetFirstProviderByName(string name, List<Provider> Myproviders)
        {
            ////version classique
            //foreach (Provider p in Myproviders)
            //{
            //    if (p.UserName.StartsWith(name))
            //        return p;
            //}
            //return null;

            // linq

            /* var query = from p in Myproviders
                         where p.UserName.StartsWith(name)
                         select p;
             return query.FirstOrDefault();*/

            //return (from p in Myproviders
            //        where p.UserName.StartsWith(name)
            //        select p).FirstOrDefault();

            return Myproviders.Where(p => p.UserName.Contains(name)).FirstOrDefault();
        }
        public Provider GetProviderById(int id, List<Provider> Myproviders)
        {
            var query = from p in Myproviders
                        where p.Id.Equals(id)
                        select p;
            return query.SingleOrDefault();
        }





    }
}
