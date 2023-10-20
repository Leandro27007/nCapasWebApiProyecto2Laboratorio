using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.BLL.Interfaces;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        //TODO: hacer
        private readonly IMedicoService _medicoService;
        public MedicoController(IMedicoService medicoService)
        {
            this._medicoService = medicoService;
        }

        [HttpGet("BuscarPacientePorIdRecibo {idRecibo}")]
        public async Task<ActionResult> BuscarPacientePorReciboId(int idRecibo)
        {
            try
            {
                var resultado = await _medicoService.BuscarPaciente(idRecibo);

                return Ok(resultado);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("PacientesPendientes")]
        public async Task<ActionResult> ListarPacientesPendientes()
        {
            try
            {
                var resultado = await _medicoService.ListarPacientesEnEspera();

                return Ok(resultado);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpGet("EstadosDeRecibo")]
        public async Task<ActionResult> ObtenerEstadosDeRecibo()
        {
            try
            {
                var resultado = await _medicoService.ObtenerEstadosDeRecibo();

                return Ok(resultado);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Cambia el estado del recibo(consultaMedica) a Completado o EsperaResultados
        /// </summary>
        /// <returns></returns>
        [HttpPost("CambiarEstadoRecibo")]
        public async Task<ActionResult> CambiarEstadoRecibo([FromHeader] int idRecibo, [FromHeader] string nuevoEstado)
        {
            try
            {
                var resultado = await _medicoService.CambiarEstadoDeRecibo(idRecibo, nuevoEstado);

                return Ok(resultado);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
