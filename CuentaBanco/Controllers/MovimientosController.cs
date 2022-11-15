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
    public class MovimientosController : ApiController
    {
        private readonly IMovimientosInteractor _movimientosInteractor;

        public MovimientosController(IMovimientosInteractor movimientosInteractor)
        {
            _movimientosInteractor = movimientosInteractor ?? throw new ArgumentNullException(nameof(movimientosInteractor));
        }

        [HttpPost]
        public IActionResult Post(Movimientos movimientos)
        {
            Response response = _movimientosInteractor.InsertMovimientos(movimientos);
            return GetStatus(response.Status, response);
        }

        [HttpGet]
        public IActionResult Get()
        {
            Response response = _movimientosInteractor.GetMovimientos();
            return GetStatus(response.Status, response);
        }

        [HttpPut]
        public IActionResult Put(Movimientos movimientos)
        {
            Response response = _movimientosInteractor.UpdateMovimientos(movimientos);
            return GetStatus(response.Status, response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response response = _movimientosInteractor.DeleteMovimientos(id);
            return GetStatus(response.Status, response);
        }
    }
}
