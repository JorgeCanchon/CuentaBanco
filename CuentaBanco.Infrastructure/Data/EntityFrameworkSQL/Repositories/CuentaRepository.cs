using CuentaBanco.Core.Entities;
using CuentaBanco.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Infrastructure.Data.EntityFrameworkSQL.Repositories
{
    public class CuentaRepository : RepositoryBase<Cuenta>, ICuentaRepository
    {
        private readonly RepositoryContextSQL _repositoryContextSqlServer;

        public CuentaRepository(RepositoryContextSQL repositoryContextSqlServer)
            : base(repositoryContextSqlServer)
        {
            _repositoryContextSqlServer = repositoryContextSqlServer ?? throw new ArgumentNullException(nameof(repositoryContextSqlServer));
        }
    }
}
