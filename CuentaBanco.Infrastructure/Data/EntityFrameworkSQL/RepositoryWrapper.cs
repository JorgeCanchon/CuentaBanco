using CuentaBanco.Core.Interfaces.Repositories;
using CuentaBanco.Infrastructure.Data.EntityFrameworkSQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Infrastructure.Data.EntityFrameworkSQL
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContextSQL _repositoryContextSqlServer;
        public IClienteRepository clienteRepository;
        public ICuentaRepository cuentaRepository;
        public IMovimientosRepository movimientosRepository;

        public RepositoryWrapper(RepositoryContextSQL repositoryContextSqlServer)
        {
            _repositoryContextSqlServer = repositoryContextSqlServer ?? throw new ArgumentNullException(nameof(repositoryContextSqlServer));
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                if (clienteRepository == null)
                    return clienteRepository = new ClienteRepository(_repositoryContextSqlServer);
                return clienteRepository;
            }
        }

        public ICuentaRepository CuentaRepository
        {
            get
            {
                if (cuentaRepository == null)
                    return cuentaRepository = new CuentaRepository(_repositoryContextSqlServer);
                return cuentaRepository;
            }
        }

        public IMovimientosRepository MovimientosRepository
        {
            get
            {
                if (movimientosRepository == null)
                    return movimientosRepository = new MovimientosRepository(_repositoryContextSqlServer);
                return movimientosRepository;
            }
        }
    }
}
