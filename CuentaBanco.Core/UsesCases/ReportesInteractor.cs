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
        private readonly IReporteEstadoCuentaRepository _reporteEstadoCuentaRepository;

        public ReportesInteractor(IRepositoryWrapper repositoryWrapper)
        {
            var _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
            _reporteEstadoCuentaRepository = _repositoryWrapper.ReporteEstadoCuentaRepository;
        }

        public Response EstadoDeCuenta(string identificacion, DateTime fechaInicio, DateTime fechaFinal)
        {
            Func<Response> func = () =>
            {
                string sql = $"EXEC dbo.ReporteEstadoDeCuenta '{identificacion}','{fechaInicio}','{fechaFinal}'";
                var reporte = _reporteEstadoCuentaRepository.ExecuteQuery(sql).ToList();

                return reporte.Any() ?
                    new Response() { Status = (int)HttpStatusCode.OK, Message = OK, Payload = reporte } :
                    new Response() { Status = (int)HttpStatusCode.NotContent, Message = NO_CONTENT, Payload = null };
            };

            return GetStatus(func);
        }
    }
}
