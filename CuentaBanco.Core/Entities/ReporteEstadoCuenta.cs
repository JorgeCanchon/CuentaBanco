using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Entities
{
    public class ReporteEstadoCuenta
    {
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal Saldo { get; set; }
        public bool Estado { get; set; }
        public string Valor { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
