using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Entities
{
    public class Cuenta
    {
        public int ID { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public int IDCliente { get; set; }
        public bool Estado { get; set; }

        public bool ValidateBalance(decimal debito)
        {
            return SaldoInicial > 0 && SaldoInicial - debito > 0;
        }
    }
}
