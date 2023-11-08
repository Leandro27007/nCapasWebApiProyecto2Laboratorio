using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.BLL.Implementaciones;
using Proyecto2Laboratorio.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private IReporteService _reporteService;
        public ReporteController(IReporteService reporteService)
        {
            this._reporteService = reporteService;
        }


        [HttpGet("ListarPruebas")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<ReporteDTO>> ListarPruebas([FromQuery] DateTime FechaInicio, [FromQuery] DateTime FechaFinal)
        {
            var resultado = await _reporteService.ObtenerReportesVentas(FechaInicio, FechaFinal);
            return Ok(resultado);
        }

    }
}
