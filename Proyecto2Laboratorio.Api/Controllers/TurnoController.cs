using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.Entities;
using System.Collections.Generic;

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
        public string GenerarTurno(List<PruebaDeLaboratorio> pruebaDeLaboratorios)
        {
            //ToDo: Hacer esto

            //s_turnoService.GenerarTurno(pruebaDeLaboratorios);

            return " ";

        }
    }
}
