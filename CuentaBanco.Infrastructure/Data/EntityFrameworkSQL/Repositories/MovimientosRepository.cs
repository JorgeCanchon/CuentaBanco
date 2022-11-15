using CuentaBanco.Core.Entities;
using CuentaBanco.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Infrastructure.Data.EntityFrameworkSQL.Repositories
{
    public class MovimientosRepository : RepositoryBase<Movimientos>, IMovimientosRepository
    {
        private readonly RepositoryContextSQL _repositoryContextSqlServer;

        public MovimientosRepository(RepositoryContextSQL repositoryContextSqlServer)
            : base(repositoryContextSqlServer)
        {
            _repositoryContextSqlServer = repositoryContextSqlServer ?? throw new ArgumentNullException(nameof(repositoryContextSqlServer));
        }
    }
}
