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
    public class MovimientosInteractor : StatusInteractor, IMovimientosInteractor
    {
        private readonly IMovimientosRepository _movimientosRepository;
        public MovimientosInteractor(IRepositoryWrapper repositoryWrapper)
        {
            var _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
            _movimientosRepository = _repositoryWrapper.MovimientosRepository;
        }

        public Response InsertMovimientos(Movimientos movimientos)
        {
            Func<Response> func = () =>
            {
                var entity = _movimientosRepository.Create(movimientos);

                return entity.ID >= 0 ?
                     new Response() { Status = (int)HttpStatusCode.Created, Message = PUSH_MESSAGE, Payload = movimientos.ID } :
                     new Response() { Status = (int)HttpStatusCode.BadRequest, Message = ERROR_PUSH_MESSAGE, Payload = null };
            };

            return GetStatus(func);
        }

        public Response GetMovimientos()
        {
            Func<Response> func = () =>
            {
                var tasks = _movimientosRepository.FindAll();

                return tasks.Any() ?
                    new Response() { Status = (int)HttpStatusCode.OK, Message = OK, Payload = tasks } :
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
