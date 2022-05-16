using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Data.Infrastructures
{
   public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IRepositoryBase<T> getRepository<T>() where T : class;
    }
}
