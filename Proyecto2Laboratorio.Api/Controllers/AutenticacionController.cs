using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.BLL.Interfaces;
using SharedLibrary.Models;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {

        private readonly ILoginService service;
        public AutenticacionController(ILoginService service)
        {
            this.service = service;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse>> LoginUserAsync(Login model)
        {
            if (model is null) return BadRequest();
            var result = await service.LoginUserAsync(model);
            return Ok(result);
        }


    }
}
