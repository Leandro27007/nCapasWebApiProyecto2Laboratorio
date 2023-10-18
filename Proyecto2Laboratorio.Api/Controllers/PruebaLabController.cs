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

    }
}
