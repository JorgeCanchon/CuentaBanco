using CuentaBanco.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Interfaces.UsesCases
{
    public interface IReportesInteractor
    {
        Response EstadoDeCuenta(string identificacion, DateTime fechaInicio, DateTime fechaFinal);
    }
}
