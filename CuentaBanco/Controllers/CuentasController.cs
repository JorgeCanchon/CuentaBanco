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
    public class CuentasController : ApiController
    {
        private readonly ICuentaInteractor _cuentaInteractor;

        public CuentasController(ICuentaInteractor cuentaInteractor)
        {
            _cuentaInteractor = cuentaInteractor ?? throw new ArgumentNullException(nameof(cuentaInteractor));
        }

        [HttpPost]
        public IActionResult Post(Cuenta cuenta)
        {
            Response response = _cuentaInteractor.InsertCuenta(cuenta);
            return GetStatus(response.Status, response);
        }

        [HttpGet]
        public IActionResult Get()
        {
            Response response = _cuentaInteractor.GetCuentas();
            return GetStatus(response.Status, response);
        }

        [HttpPut]
        public IActionResult Put(Cuenta cuenta)
        {
            Response response = _cuentaInteractor.UpdateCuenta(cuenta);
            return GetStatus(response.Status, response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response response = _cuentaInteractor.DeleteCuenta(id);
            return GetStatus(response.Status, response);
        }
    }
}
