using CuentaBanco.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Infrastructure.Data.EntityFrameworkSQL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DbContext Context { get; set; }
        private bool _disposed;

        protected RepositoryBase(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public T Create(T entity)
        {
            T result = Context.Set<T>().Add(entity).Entity;
            Context.SaveChanges();
            return result;
        }

        public IQueryable<T> FindAll() =>
            Context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Context.Set<T>().Where(expression).AsNoTracking();

        public T FindById(int id) =>
            Context.Set<T>().Find(id);

        public T Update(T entity)
        {
            Context.Attach(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public T Delete(int id)
        {
            var entity = Context.Set<T>().Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException("Not found entity");
            }
            Context.Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                    Context = null;
                }
            }
            _disposed = true;
        }
    }
}
