using System;
using System.Linq;
using System.Linq.Expressions;

namespace Contracts
{
   public interface IRepositoryBase<T>
   {
      IQueryable<T> FindAll(bool trackChanges);
      IQueryable<T> FIndByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
      void Create(T entitty);
      void Delete(T entitty);
      void Update(T entitty);
   }
}
