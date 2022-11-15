using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CuentaBanco.Core.Common.Constantes;

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
        [NotMapped]
        public string NumeroCuenta { get; set; }

        public bool ValidTipoMovimiento()
        {
            return new string[] { DEBITO, CREDITO }.Contains(TipoMovimiento);
        }

        public bool IsDebito() =>
            TipoMovimiento.Equals(DEBITO);

        public bool IsCredito() =>
            TipoMovimiento.Equals(CREDITO);
    }
}
