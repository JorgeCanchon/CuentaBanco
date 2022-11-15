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
    public class ReportesController : ApiController
    {
        private readonly IReportesInteractor _reportesInteractor;

        public ReportesController(IReportesInteractor reportesInteractor)
        {
            _reportesInteractor = reportesInteractor ?? throw new ArgumentNullException(nameof(reportesInteractor));
        }

        [HttpGet]
        public IActionResult Get(string identificacion, DateTime fechaInicio, DateTime fechaFinal)
        {
            Response response = _reportesInteractor.EstadoDeCuenta(identificacion, fechaInicio, fechaFinal);
            return GetStatus(response.Status, response);
        }
    }
}
