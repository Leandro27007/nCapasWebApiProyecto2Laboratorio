using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.Entities;
using System.Collections.Generic;
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


        [HttpPost(Name = "GenerarTurno")]
        public async Task<ActionResult> GenerarTurno(List<PruebaDeLaboratorio> pruebaDeLaboratorios)
        {
            var turno = await _turnoService.GenerarTurno(pruebaDeLaboratorios);

            return Ok("Tu numero de turno es: "+turno.TurnoId);
        }

        [HttpPut(Name = "CancelarTurno")]
        public async Task<ActionResult> CancelarTurno(string TurnoId)
        {
            var resultado = await _turnoService.CancelarTurno(TurnoId);

            if (!resultado)
            {
                return NotFound(resultado);
            }

            return Ok(resultado);
        }
        [HttpDelete(Name = "ResetearTurnos")]
        public async Task<ActionResult> ResetearTurnos()
        {

            var resultado = await _turnoService.ResetearTurnos();

            if (!resultado)
            {
                return NotFound(resultado);
            }

            return Ok("Turno reseteados correctamente"+resultado);

        }
    }
}
