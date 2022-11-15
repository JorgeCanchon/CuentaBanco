using CuentaBanco.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Interfaces.UsesCases
{
    public interface ICuentaInteractor
    {
        Response InsertCuenta(Cuenta cuenta);
        Response GetCuentas();
        Response UpdateCuenta(Cuenta cuenta);
        Response DeleteCuenta(int id);
    }
}
