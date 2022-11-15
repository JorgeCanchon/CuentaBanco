using CuentaBanco.Common;
using CuentaBanco.Core.Entities;
using CuentaBanco.Core.Interfaces.UsesCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentaBanco.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ApiController
    {
        private readonly IClienteInteractor _clienteInteractor;

        public ClientesController(IClienteInteractor clienteInteractor)
        {
            _clienteInteractor = clienteInteractor ?? throw new ArgumentNullException(nameof(clienteInteractor));
        }

        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            Response response = _clienteInteractor.InsertClient(cliente);
            return GetStatus(response.Status, response);
        }

        [HttpGet]
        public IActionResult Get()
        {
            Response response = _clienteInteractor.GetClients();
            return GetStatus(response.Status, response);
        }

        [HttpPut]
        public IActionResult Put(Cliente cliente)
        {
            Response response = _clienteInteractor.UpdateClient(cliente);
            return GetStatus(response.Status, response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response response = _clienteInteractor.DeleteClient(id);
            return GetStatus(response.Status, response);
        }
    }
}
