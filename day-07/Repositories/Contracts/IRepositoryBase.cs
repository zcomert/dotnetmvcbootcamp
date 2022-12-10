﻿
using System.Linq.Expressions;


namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        T FindById(Expression<Func<T, bool>> filter);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);  
    }
}
