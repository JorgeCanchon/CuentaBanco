using CuentaBanco.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core.Strategy
{
    public class TransactionStrategy
    {
        private readonly ITransactionStrategy _transactionStrategy;

        public TransactionStrategy()
        {

        }

        public TransactionStrategy(ITransactionStrategy transactionStrategy)
        {
            _transactionStrategy = transactionStrategy ?? throw new ArgumentNullException(nameof(transactionStrategy)); 
        }

        public decimal CalculateBalance(decimal balance, decimal value)
        {
            return _transactionStrategy.CalculateBalance(balance, value);
        }
    }
}
