using CuentaBanco.Core.Entities;
using CuentaBanco.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Infrastructure.Data.EntityFrameworkSQL.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        private readonly RepositoryContextSQL _repositoryContextSqlServer;

        public ClienteRepository(RepositoryContextSQL repositoryContextSqlServer)
            : base(repositoryContextSqlServer)
        {
            _repositoryContextSqlServer = repositoryContextSqlServer ?? throw new ArgumentNullException(nameof(repositoryContextSqlServer));
        }
    }
}
