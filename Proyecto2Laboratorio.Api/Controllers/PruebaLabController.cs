using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.BLL.Interfaces;
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
        public async Task<ActionResult> ListarPruebas([FromQuery] int PaginaActual = 1)
        {
            var resultado = await _pruebasLabService.ListarPruebas();
            return Ok(resultado);
        }

        [HttpPost("CrearPruebaLab")]
        public async Task<ActionResult> CrearPrueba([FromBody] CreacionPruebaLabDTO creacionPruebaLabDTO)
        {
            var resultado = await _pruebasLabService.CrearPruebaLabAsync(creacionPruebaLabDTO);
            return Ok(resultado);
        }

        [HttpPut("EditarPruebaLab")]
        public async Task<ActionResult> EditarPrueba([FromBody] EdicionPruebaLabDTO edicionPruebaLabDTO)
        {
            var resultado = await _pruebasLabService.EditarPruebaLabAsync(edicionPruebaLabDTO);
            return Ok(resultado);
        }


        [HttpDelete("EliminarPruebaLab{id}")]
        public async Task<ActionResult> EliminarPrueba(int id)
        {
            var resultado = await _pruebasLabService.EliminarPruebaLabAsync(id);
            return Ok(resultado);
        }

    }
}