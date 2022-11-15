using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Entities
{
    public class Movimientos
    {
        public int ID { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public int IDCliente { get; set; }
        public int IDCuenta { get; set; }
    }
}
