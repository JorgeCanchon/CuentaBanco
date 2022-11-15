using CuentaBanco.Core.Entities;
using CuentaBanco.Core.Interfaces.Repositories;
using CuentaBanco.Core.Interfaces.UsesCases;
using System;
using static CuentaBanco.Core.Common.Constantes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuentaBanco.Core.Common;
using CuentaBanco.Core.Strategy;

namespace CuentaBanco.Core.UsesCases
{
    public class MovimientosInteractor : StatusInteractor, IMovimientosInteractor
    {
        private readonly IMovimientosRepository _movimientosRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public MovimientosInteractor(IRepositoryWrapper repositoryWrapper)
        {
            var _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
            _movimientosRepository = _repositoryWrapper.MovimientosRepository;
            _cuentaRepository = _repositoryWrapper.CuentaRepository;
        }

        public Response InsertMovimientos(Movimientos movimientos)
        {
            Func<Response> func = () =>
            {
                var cuenta = _cuentaRepository.FindByCondition(cuenta => cuenta.NumeroCuenta.Equals(movimientos.NumeroCuenta)).FirstOrDefault();
                var validation = IsInvalidTransaction(movimientos, cuenta);

                if (validation != null)
                    return validation;

                movimientos.Saldo = cuenta.SaldoInicial;
                movimientos.IDCuenta = cuenta.ID;
                var entity = _movimientosRepository.Create(movimientos);

                if(entity.ID > 0)
                {
                    cuenta.SaldoInicial = SetBalance(movimientos, cuenta);
                    _cuentaRepository.Update(cuenta);
                    return new Response() { Status = (int)HttpStatusCode.Created, Message = PUSH_MESSAGE, Payload = movimientos.ID };
                }
                return new Response() { Status = (int)HttpStatusCode.BadRequest, Message = ERROR_PUSH_MESSAGE, Payload = null };
            };

            return GetStatus(func);
        }

        public decimal SetBalance(Movimientos movimientos, Cuenta cuenta)
        {
            TransactionStrategy transactionStrategy = null;

            if (movimientos.IsCredito())
            {
                transactionStrategy = new TransactionStrategy(new CreditoStrategy());
            }
            else if (movimientos.IsDebito())
            {
                transactionStrategy = new TransactionStrategy(new DebitoStrategy());
            }

            return transactionStrategy.CalculateBalance(cuenta.SaldoInicial, movimientos.Valor);
        }

        public Response IsInvalidTransaction(Movimientos movimientos, Cuenta cuenta)
        {
            string message = ValidTransaction(movimientos, cuenta);
            if (!string.IsNullOrEmpty(message))
            {
                return new Response() { Status = (int)HttpStatusCode.InternalServerError, Message = message, Payload = null };
            }
            return null;
        }

        public string ValidTransaction(Movimientos movimientos, Cuenta cuenta)
        {
            string response = string.Empty;
            if (!movimientos.ValidTipoMovimiento())
                response = INVALID_MOVEMENT_TYPE;

            if (movimientos.IsDebito() && !cuenta.ValidateBalance(movimientos.Valor))
                response = SALDO_NO_DISPONIBLE;

            return response;
        }

        public Response GetMovimientos()
        {
            Func<Response> func = () =>
            {
                var movimientos = _movimientosRepository.FindAll();

                return movimientos.Any() ?
                    new Response() { Status = (int)HttpStatusCode.OK, Message = OK, Payload = movimientos } :
                    new Response() { Status = (int)HttpStatusCode.NotContent, Message = NO_CONTENT, Payload = null };
            };

            return GetStatus(func);
        }

        public Response UpdateMovimientos(Movimientos movimientos)
        {
            Func<Response> func = () =>
            {
                var result = _movimientosRepository.Update(movimientos);
                return result.ID > 0 ?
                        new Response() { Status = (int)HttpStatusCode.OK, Message = UPDATE_MESSAGE, Payload = null } :
                        new Response() { Status = (int)HttpStatusCode.BadRequest, Message = ERROR_UPDATE_MESSAGE, Payload = null };
            };

            return GetStatus(func);
        }

        public Response DeleteMovimientos(int id)
        {
            Func<Response> func = () =>
            {
                var result = _movimientosRepository.Delete(id);

                return result.ID > 0 ?
                       new Response() { Status = (int)HttpStatusCode.OK, Message = DELETE_MESSAGE, Payload = result.ID } :
                       new Response() { Status = (int)HttpStatusCode.Accepted, Message = ERROR_DELETE_MESSAGE, Payload = null };
            };

            return GetStatus(func);
        }
    }
}
