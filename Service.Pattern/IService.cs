using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service.Pattern
{
    public interface IService<T> : IDisposable where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> condition);
        T GetById(int Id);
        T GetById(string Id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll(); // GetMany()
        IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null);
        void Commit();
    }
}
