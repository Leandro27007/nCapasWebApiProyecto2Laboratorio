using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto2Laboratorio.BLL.Implementaciones;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.Entities;
using System.Threading.Tasks;

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






    }
}
