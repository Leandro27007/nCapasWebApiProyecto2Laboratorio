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
    public class PruebaLabController : ControllerBase
    {

        private readonly IPruebasLabService _pruebasLabService;

        public PruebaLabController(IPruebasLabService pruebasLabService)
        {
            _pruebasLabService = pruebasLabService;
        }

        [HttpGet("ListarPruebas")]
        [Authorize(Roles = "Medico,Administrador,Cajero,Usuario")]
        public async Task<ActionResult<IEnumerable<PruebaLabDTO>>> ListarPruebas([FromQuery] int PaginaActual = 1)
        {
            var resultado = await _pruebasLabService.ListarPruebas();
            return Ok(resultado);
        }

        [HttpPost("CrearPruebaLab")]
        [Authorize(Roles = "Usuario,Administrador")]
        public async Task<ActionResult<PruebaLabDTO>> CrearPrueba([FromBody] CreacionPruebaLabDTO creacionPruebaLabDTO)
        {
            var resultado = await _pruebasLabService.CrearPruebaLabAsync(creacionPruebaLabDTO);
            return Ok(resultado);
        }

        [HttpPut("EditarPruebaLab")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<bool>> EditarPrueba([FromBody] EdicionPruebaLabDTO edicionPruebaLabDTO)
        {
            var resultado = await _pruebasLabService.EditarPruebaLabAsync(edicionPruebaLabDTO);
            return Ok(resultado);
        }


        [HttpDelete("EliminarPruebaLab{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<bool>> EliminarPrueba(int id)
        {
            var resultado = await _pruebasLabService.EliminarPruebaLabAsync(id);
            return Ok(resultado);
        }

    }
}