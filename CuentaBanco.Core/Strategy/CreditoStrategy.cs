using CuentaBanco.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Strategy
{
    public class CreditoStrategy : ITransactionStrategy
    {
        public decimal CalculateBalance(decimal balance, decimal value)
        {
            return balance + value;
        }
    }
}
