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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        [HttpGet("ListarUsuario")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<List<UsuarioDTO>>> ListarUsuario()
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
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<UsuarioDTO>> BuscarUsuario(string Cedula)
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
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<UsuarioDTO>> CrearUsuario([FromBody] UsuarioCreacionDTO usuarioCreacionDTO)
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
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<bool>> EditarUsuario([FromBody] UsuarioEdicionDTO usuarioEdicionDTO)
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
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<bool>> EliminarUsuario(string Cedula)
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
