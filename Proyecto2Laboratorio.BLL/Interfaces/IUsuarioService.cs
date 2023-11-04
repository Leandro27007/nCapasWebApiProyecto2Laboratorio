using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>?> ListarUsuario();
        Task<UsuarioDTO?> CrearUsuarioAsync(UsuarioCreacionDTO creacionPruebaLabDTO);
        Task<UsuarioDTO?> BuscarUsuarioAsync(string cedula);
        Task<bool?> EditarUsuarioAsync(UsuarioEdicionDTO creacionPruebaLabDTO);
        Task<bool?> EliminarUsuarioAsync(string cedula);

    }
}
