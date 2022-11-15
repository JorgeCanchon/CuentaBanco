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
    public class ClienteInteractor : StatusInteractor, IClienteInteractor
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteInteractor(IRepositoryWrapper repositoryWrapper)
        {
            var _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
            _clienteRepository = _repositoryWrapper.ClienteRepository;
        }

        public Response InsertClient(Cliente cliente)
        {
            Func<Response> func = () =>
            {
                cliente.Contrasena = cliente.Contrasena.EncryptToBase64();
                var entity = _clienteRepository.Create(cliente);

                return entity.ID >= 0 ?
                     new Response() { Status = (int)HttpStatusCode.Created, Message = PUSH_MESSAGE, Payload = cliente.ID } :
                     new Response() { Status = (int)HttpStatusCode.BadRequest, Message = ERROR_PUSH_MESSAGE, Payload = null };
            };

            return GetStatus(func);
        }

        public Response GetClients()
        {
            Func<Response> func = () =>
            {
                var tasks = _clienteRepository.FindAll().AsEnumerable().Select(client => new Cliente()
                {
                    ID = client.ID,
                    Identificacion = client.Identificacion,
                    Direccion = client.Direccion,
                    Estado = client.Estado,
                    FechaNacimiento = client.FechaNacimiento,
                    Genero = client.Genero,
                    Nombre = client.Nombre,
                    Telefono = client.Telefono,
                    Contrasena = client.Contrasena.DecryptToBase64()
                }).ToList();

                return tasks.Any() ?
                    new Response() { Status = (int)HttpStatusCode.OK, Message = OK, Payload = tasks } :
                    new Response() { Status = (int)HttpStatusCode.NotContent, Message = NO_CONTENT, Payload = null };
            };

            return GetStatus(func);
        }

        public Response UpdateClient(Cliente cliente)
        {
            Func<Response> func = () =>
            {
                cliente.Contrasena = cliente.Contrasena.EncryptToBase64();
                var result = _clienteRepository.Update(cliente);
                return result.ID > 0 ?
                        new Response() { Status = (int)HttpStatusCode.OK, Message = UPDATE_MESSAGE, Payload = null } :
                        new Response() { Status = (int)HttpStatusCode.BadRequest, Message = ERROR_UPDATE_MESSAGE, Payload = null };
            };

            return GetStatus(func);
        }

        public Response DeleteClient(int id)
        {
            Func<Response> func = () =>
            {
                var result = _clienteRepository.Delete(id);

                return result.ID > 0 ?
                       new Response() { Status = (int)HttpStatusCode.OK, Message = DELETE_MESSAGE, Payload = result.ID } :
                       new Response() { Status = (int)HttpStatusCode.Accepted, Message = ERROR_DELETE_MESSAGE, Payload = null };
            };

            return GetStatus(func);
        }
    }
}
