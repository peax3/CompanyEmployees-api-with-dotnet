using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace Repository
{
   public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
   {
      protected RepositoryContext RepositoryContext;

      public RepositoryBase(RepositoryContext repositoryContext)
      {
         RepositoryContext = repositoryContext;
      }

      public IQueryable<T> FindAll(bool trackChanges)
      {
         var entities = !trackChanges ?
                                    RepositoryContext.Set<T>().AsNoTracking() :
                                    RepositoryContext.Set<T>();

         return entities;
      }

      public IQueryable<T> FIndByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
      {
         var entities = !trackChanges ?
                                    RepositoryContext.Set<T>().Where(expression).AsNoTracking() :
                                    RepositoryContext.Set<T>().Where(expression);

         return entities;
      }

      public void Create(T entitty)
      {
         RepositoryContext.Set<T>().Add(entitty);
      }

      public void Delete(T entitty)
      {
         RepositoryContext.Set<T>().Remove(entitty);
      }

      public void Update(T entitty)
      {
         RepositoryContext.Set<T>().Update(entitty);
      }
   }
}
