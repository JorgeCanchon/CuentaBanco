using CuentaBanco.Core.Common;
using CuentaBanco.Core.Entities;
using CuentaBanco.Core.Interfaces.Repositories;
using CuentaBanco.Core.Interfaces.UsesCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CuentaBanco.Core.Common.Constantes;

namespace CuentaBanco.Core.UsesCases
{
    public class ReportesInteractor : StatusInteractor, IReportesInteractor
    {
        private readonly IMovimientosRepository _movimientosRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public ReportesInteractor(IRepositoryWrapper repositoryWrapper)
        {
            var _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
            _movimientosRepository = _repositoryWrapper.MovimientosRepository;
            _cuentaRepository = _repositoryWrapper.CuentaRepository;
        }

        public Response EstadoDeCuenta(DateTime fechaInicio, DateTime fechaFinal)
        {
            Func<Response> func = () =>
            {
                var movimientos = _movimientosRepository.FindAll();

                return movimientos.Any() ?
                    new Response() { Status = (int)HttpStatusCode.OK, Message = OK, Payload = movimientos } :
                    new Response() { Status = (int)HttpStatusCode.NotContent, Message = NO_CONTENT, Payload = null };
            };

            return GetStatus(func);
        }
    }
}
