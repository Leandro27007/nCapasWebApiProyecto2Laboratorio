using DTOs;
using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.BLL.Interfaces;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        [HttpGet("ListarUsuario")]
        public async Task<ActionResult> ListarUsuario()
        {
            try
            {
            var resultado = await _usuarioService.ListarUsuario();
            return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("BuscarUsuario{Cedula}")]
        public async Task<ActionResult> BuscarUsuario(string Cedula)
        {
            try
            {
                var resultado = await _usuarioService.BuscarUsuarioAsync(Cedula);
                if (resultado != null)
                {
                    return Ok(resultado);
                }
                return NotFound("No se encontro el usuario");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("CrearUsuario")]
        public async Task<ActionResult> CrearUsuario([FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var resultado = await _usuarioService.CrearUsuarioAsync(usuarioCreacionDTO);
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("EditarUsuario")]
        public async Task<ActionResult> EditarUsuario([FromBody] UsuarioEdicionDTO usuarioEdicionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var resultado = await _usuarioService.EditarUsuarioAsync(usuarioEdicionDTO);
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("EliminarUsuario{Cedula}")]
        public async Task<ActionResult> EliminarUsuario(string Cedula)
        {
            try
            {
                var resultado = await _usuarioService.EliminarUsuarioAsync(Cedula);
                return Ok(resultado);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
