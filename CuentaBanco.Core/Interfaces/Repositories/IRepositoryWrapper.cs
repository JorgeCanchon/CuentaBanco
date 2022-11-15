using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IClienteRepository ClienteRepository { get; }
        ICuentaRepository CuentaRepository { get; }
        IMovimientosRepository MovimientosRepository { get; }
        IReporteEstadoCuentaRepository ReporteEstadoCuentaRepository { get; }
    }
}
