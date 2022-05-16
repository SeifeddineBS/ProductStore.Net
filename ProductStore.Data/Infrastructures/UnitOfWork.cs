using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Data.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
       
        readonly IDataBaseFactory _dbFactory;
        //1//
        public UnitOfWork(IDataBaseFactory dbFactory) 
        {
            _dbFactory = dbFactory; 
        }

        //la mise à jour / saveChanges()
        //3//
        public void Commit() {

            _dbFactory.DataContext.SaveChanges();
        }

        //2 CRUD Génerique//
        public IRepositoryBase<T> getRepository<T>() where T : class
        {
            return new RepositoryBase<T>(_dbFactory);
        }

        //4//
        public void Dispose() { 
            _dbFactory.DataContext.Dispose(); 
        }
    }
}
