using DTOs;
using Microsoft.EntityFrameworkCore;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Implementaciones
{

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
                this._usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<UsuarioDTO?> BuscarUsuarioAsync(string cedula)
        {
            var usuario = await _usuarioRepositorio.Consultar().Where(u => u.UsuarioId == cedula).FirstOrDefaultAsync();

            if (usuario == null)
                return null;

            return new() 
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Cedula = usuario.UsuarioId,
                Email = usuario.Email,
                Telefono = usuario.Telefono
            };
        }

        public async Task<UsuarioDTO?> CrearUsuarioAsync(UsuarioCreacionDTO usuarioCreacionDTO)
        {
            try
            {
                await _usuarioRepositorio.Crear(new Entities.Usuario()
                {
                    Nombre = usuarioCreacionDTO.Nombre,
                    Apellido = usuarioCreacionDTO.Apellido,
                    Username = usuarioCreacionDTO.Username,
                    Password = usuarioCreacionDTO.Password,
                    Telefono = usuarioCreacionDTO.Telefono,
                    Email = usuarioCreacionDTO.Email,
                    UsuarioId = usuarioCreacionDTO.Cedula,
                    FechaRegistro = DateTime.Now
                });

                return new UsuarioDTO()
                {
                    Cedula = usuarioCreacionDTO.Cedula,
                    Nombre = usuarioCreacionDTO.Nombre,
                    Apellido = usuarioCreacionDTO.Apellido,
                    Email = usuarioCreacionDTO.Email,
                    Telefono = usuarioCreacionDTO.Telefono
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool?> EditarUsuarioAsync(UsuarioEdicionDTO creacionPruebaLabDTO)
        {
            try
            {
                await _usuarioRepositorio.Editar(new Entities.Usuario()
                {
                    Nombre = creacionPruebaLabDTO.Nombre,
                    Apellido = creacionPruebaLabDTO.Apellido,
                    Telefono = creacionPruebaLabDTO.Telefono,
                    Email = creacionPruebaLabDTO.Email,
                    UsuarioId = creacionPruebaLabDTO.Cedula,
                    FechaRegistro = DateTime.Now
                });

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool?> EliminarUsuarioAsync(string cedula)
        {
            try
            {
                var usuarioParaEliminar = await _usuarioRepositorio.Obtener(d => d.UsuarioId == cedula);

                if (usuarioParaEliminar != null)
                {
                    await _usuarioRepositorio.Eliminar(usuarioParaEliminar);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<UsuarioDTO>?> ListarUsuario()
        {
            var usuarios = await _usuarioRepositorio.Consultar().ToListAsync();

            return usuarios.Select(u => new UsuarioDTO() 
            {
                Cedula = u.UsuarioId,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Telefono = u.Telefono,
                Email = u.Email
            }).ToList();
        }
    }
}
