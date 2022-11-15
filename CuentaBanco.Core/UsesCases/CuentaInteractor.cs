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

namespace CuentaBanco.Core.UsesCases
{
    public class CuentaInteractor : StatusInteractor, ICuentaInteractor
    {
        private readonly ICuentaRepository _cuentaRepository;
        public CuentaInteractor(IRepositoryWrapper repositoryWrapper)
        {
            var _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
            _cuentaRepository = _repositoryWrapper.CuentaRepository;
        }

        public Response InsertCuenta(Cuenta cuenta)
        {
            Func<Response> func = () =>
            {
                var entity = _cuentaRepository.Create(cuenta);

                return entity.ID >= 0 ?
                     new Response() { Status = (int)HttpStatusCode.Created, Message = PUSH_MESSAGE, Payload = cuenta.ID } :
                     new Response() { Status = (int)HttpStatusCode.BadRequest, Message = ERROR_PUSH_MESSAGE, Payload = null };
            };

            return GetStatus(func);
        }

        public Response GetCuentas()
        {
            Func<Response> func = () =>
            {
                var cuentas = _cuentaRepository.FindAll();

                return cuentas.Any() ?
                    new Response() { Status = (int)HttpStatusCode.OK, Message = OK, Payload = cuentas } :
                    new Response() { Status = (int)HttpStatusCode.NotContent, Message = NO_CONTENT, Payload = null };
            };

            return GetStatus(func);
        }

        public Response UpdateCuenta(Cuenta cuenta)
        {
            Func<Response> func = () =>
            {
                var result = _cuentaRepository.Update(cuenta);
                return result.ID > 0 ?
                        new Response() { Status = (int)HttpStatusCode.OK, Message = UPDATE_MESSAGE, Payload = null } :
                        new Response() { Status = (int)HttpStatusCode.BadRequest, Message = ERROR_UPDATE_MESSAGE, Payload = null };
            };

            return GetStatus(func);
        }

        public Response DeleteCuenta(int id)
        {
            Func<Response> func = () =>
            {
                var result = _cuentaRepository.Delete(id);

                return result.ID > 0 ?
                       new Response() { Status = (int)HttpStatusCode.OK, Message = DELETE_MESSAGE, Payload = result.ID } :
                       new Response() { Status = (int)HttpStatusCode.Accepted, Message = ERROR_DELETE_MESSAGE, Payload = null };
            };

            return GetStatus(func);
        }
    }
}
