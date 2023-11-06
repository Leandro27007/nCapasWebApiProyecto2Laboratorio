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
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;
        public RolController(IRolService rolService)
        {
            this._rolService = rolService;
        }

        [HttpGet("ListarPruebas")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<List<RolObtencionDTO>>> ListarRoles()
        {
            var resultado = await _rolService.ListarRoles();
            return Ok(resultado);
        }

        [HttpPost("CrearRol")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<RolObtencionDTO>> CrearRol([FromBody] RolCreacionDTO rolCreacionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var resultado = await _rolService.CrearRol(rolCreacionDTO);
            return Ok(resultado);
        }

        [HttpPut("EditarRol")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<bool>> EditarRol([FromBody] RolEdicionDTO rolEdicionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _rolService.EditarRol(rolEdicionDTO);
            return Ok(resultado);
        }


        [HttpDelete("EliminarRol{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<bool>> EliminarRol(int id)
        {
            var resultado = await _rolService.Eliminar(id);
            return Ok(resultado);
        }



    }
}
