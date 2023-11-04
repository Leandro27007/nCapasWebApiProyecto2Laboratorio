using DTOs;
using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.BLL.Interfaces;
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
        public async Task<ActionResult> GenerarRecibo(GenerarReciboDTO reciboDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _reciboService.GenerarReciboAsync(reciboDTO);
            return Ok(resultado);
        }
       
        [HttpGet("ListarRecibos")]
        public async Task<ActionResult> ListarRecibos([FromQuery] int PaginaActual = 1)
        {
            var resultado = await _reciboService.ListarRecibosAsync(PaginaActual);
            return Ok(resultado);
        }

        [HttpGet("CheckearEstadoDeRecibo{id}")]
        public async Task<ActionResult> ObtenerEstadoDeRecibo( int id)
        {

            var resultado = await _reciboService.ObtenerEstadoReciboAsync(id);

            return Ok(resultado);
        }

        [HttpPost("Reembolsar")]
        public async Task<ActionResult> Reembolsar([FromHeader] int IdRecibo, [FromHeader] string notaModificacion)
        {
            var resultado = await _reciboService.ReembolsarReciboAsync(IdRecibo, notaModificacion);
            return Ok(resultado);
        }


    }
}