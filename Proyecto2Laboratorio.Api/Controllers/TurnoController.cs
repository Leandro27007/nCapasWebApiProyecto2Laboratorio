using DTOs;
using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.Entities;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {

        private ITurnoService _turnoService;

        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }

        [HttpGet("ListarTurnosPendientes")]
        public async Task<ActionResult> Listar( )
        {
            try
            {
                var turnos = await _turnoService.ListarTurnosPendientes();

                return Ok(turnos);
            }
            catch (System.Exception ex)
            {

                return Problem(ex.Message);
            }

        }

        [HttpGet("HistorialTurnos")]
        public async Task<ActionResult> HistorialTurnos()
        {
            var turnos = await _turnoService.HistorialTurnos();

            return Ok(turnos);
        }


        [HttpPost("GenerarTurno")]
        public async Task<ActionResult> GenerarTurno(GenerarTurnoDTO modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var turno = await _turnoService.GenerarTurno(modelo);
            return Ok("Tu numero de turno es: " + turno.TurnoId);
        }

        [HttpPut("CancelarTurno")]
        public async Task<ActionResult> CancelarTurno(string TurnoId)
        {
            var resultado = await _turnoService.CancelarTurno(TurnoId);

            if (!resultado)
            {
                return NotFound("No se encontro el turno");
            }

            return Ok(resultado);
        }


        /// <summary>
        /// Elimina Todos los registros de turnos en la base de datos
        /// </summary>
        /// <returns></returns>
        [HttpDelete("ResetearTurnos")]
        public async Task<ActionResult> ResetearTurnos()
        {

            var resultado = await _turnoService.ResetearTurnos();

            if (!resultado)
            {
                return NotFound(resultado);
            }

            return Ok("Turno reseteados correctamente" + resultado);

        }
    }
}
