using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Interfaces
{
    public interface ITransactionStrategy
    {
        decimal CalculateBalance(decimal balance, decimal value);
    }
}
