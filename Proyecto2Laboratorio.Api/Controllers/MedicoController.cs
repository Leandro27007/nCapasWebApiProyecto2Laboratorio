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
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        public MedicoController(IMedicoService medicoService)
        {
            this._medicoService = medicoService;
        }

        [HttpGet("BuscarPacientePorIdRecibo {idRecibo}")]
        [Authorize(Roles = "Medico,Administrador")]
        public async Task<ActionResult<PacienteDTO>> BuscarPacientePorReciboId(int idRecibo)
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
        [Authorize(Roles = "Medico,Administrador")]
        public async Task<ActionResult<List<PacienteDTO>>> ListarPacientesPendientes()
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
        [Authorize(Roles = "Medico,Administrador")]
        public async Task<ActionResult<List<string>>> ObtenerEstadosDeRecibo()
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
        [HttpPost("DespacharPacientePorNumeroRecibo")]
        [Authorize(Roles = "Medico,Administrador")]
        public async Task<ActionResult<bool>> CambiarEstadoRecibo([FromHeader] int idRecibo, [FromHeader] string nuevoEstado)
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
