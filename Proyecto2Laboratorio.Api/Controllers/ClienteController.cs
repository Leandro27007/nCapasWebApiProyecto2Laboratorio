using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.Entities;

namespace Proyecto2Laboratorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {

            this._clienteService = clienteService;

        }

        [HttpPost ("CrearCliente")]
        public ActionResult CrearCliente([FromBody]Cliente modelo)
        {
            try
            {
                var cliente = _clienteService.CrearClienteAsync(modelo);
                return Ok(cliente);

            }
            catch (System.Exception)
            {

                return BadRequest("Ocurrio un error, no se creo el cliente");
            }


        }








    }
}
