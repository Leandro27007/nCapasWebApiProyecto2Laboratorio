using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciboController : ControllerBase
    {
        private readonly IReciboService _reciboService;

        public ReciboController(IReciboService reciboService)
        {
                this._reciboService = reciboService;
        }

        [HttpPost("GenerarRecibo")]
        [Authorize(Roles = "Cajero,Administrador")]
        public async Task<ActionResult<ReciboDTO>> GenerarRecibo(GenerarReciboDTO reciboDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _reciboService.GenerarReciboAsync(reciboDTO);
            return Ok(resultado);
        }
       
        [HttpGet("ListarRecibos")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<List<ReciboDTO>>> ListarRecibos([FromQuery] int PaginaActual = 1)
        {
            var resultado = await _reciboService.ListarRecibosAsync(PaginaActual);
            return Ok(resultado);
        }

        [HttpGet("CheckearEstadoDeRecibo{numeroRecibo}")]
        [Authorize(Roles = "Cajero,Administrador")]
        public async Task<ActionResult> ObtenerEstadoDeRecibo(int numeroRecibo)
        {
            var resultado = await _reciboService.ObtenerEstadoReciboAsync(numeroRecibo);

            return Ok(resultado);
        }

        [HttpGet("BuscarReciboPorId{numeroRecibo}")]
        [Authorize(Roles = "Cajero,Administrador")]
        public async Task<ActionResult<ReciboDTO>> BuscarReciboPorId(int numeroRecibo)
        {

            var resultado = await _reciboService.BuscarReciboAsync(numeroRecibo);

            if (resultado == null)
            {
                return NotFound("No se encontro el recibo");
            }

            return Ok(resultado);
        }

        [HttpPost("CancelarRecibo")]
        [Authorize(Roles = "Cajero,Administrador")]
        public async Task<ActionResult<bool>> Reembolsar([FromHeader] int IdRecibo, [FromHeader] string notaModificacion)
        {
            var resultado = await _reciboService.ReembolsarReciboAsync(IdRecibo, notaModificacion);
            return Ok(resultado);
        }

    }
}