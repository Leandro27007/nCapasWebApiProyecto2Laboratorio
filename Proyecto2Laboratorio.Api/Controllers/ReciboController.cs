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

            var resultado = await _reciboService.GenerarReciboAsync(reciboDTO);

            return Ok(resultado);
        }




    }
}
