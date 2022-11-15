﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T> : IDisposable
    {
        IQueryable<T> FindAll();
        T FindById(int id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T Update(T entity);
        T Delete(int id);
        IQueryable<T> ExecuteQuery(string sql);
    }
}
