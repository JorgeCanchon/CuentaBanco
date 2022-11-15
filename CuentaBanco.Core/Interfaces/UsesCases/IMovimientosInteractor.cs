using CuentaBanco.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Interfaces.UsesCases
{
    public interface IMovimientosInteractor
    {
        Response InsertMovimientos(Movimientos movimientos);
        Response GetMovimientos();
        Response UpdateMovimientos(Movimientos movimientos);
        Response DeleteMovimientos(int id);
    }
}
