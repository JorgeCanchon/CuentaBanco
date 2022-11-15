using CuentaBanco.Core.Interfaces.Repositories;
using CuentaBanco.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Infrastructure.Data.EntityFrameworkSQL.Repositories
{
    public class ReporteEstadoCuentaRepository : RepositoryBase<ReporteEstadoCuenta>, IReporteEstadoCuentaRepository
    {
        private readonly RepositoryContextSQL _repositoryContextSqlServer;

        public ReporteEstadoCuentaRepository(RepositoryContextSQL repositoryContextSqlServer)
            : base(repositoryContextSqlServer)
        {
            _repositoryContextSqlServer = repositoryContextSqlServer ?? throw new ArgumentNullException(nameof(repositoryContextSqlServer));
        }
    }
}
