using DTOs;
using Microsoft.EntityFrameworkCore;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            var usuario = await _usuarioRepositorio.Consultar().Where(u => u.UsuarioId == cedula).Include(u => u.Role).FirstOrDefaultAsync();

            if (usuario == null)
                return null;

            return new()
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Cedula = usuario.UsuarioId,
                NombreRol = usuario.Role.NombreRol,
                UserName = usuario.Username,
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
                    Password = HashPassword(usuarioCreacionDTO.Password),
                    Telefono = usuarioCreacionDTO.Telefono,
                    Email = usuarioCreacionDTO.Email,
                    UsuarioId = usuarioCreacionDTO.Cedula,
                    RolId = usuarioCreacionDTO.IdRol,
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
                var usuarioAEditar = await _usuarioRepositorio.Obtener(u => u.UsuarioId == creacionPruebaLabDTO.Cedula);

                if (usuarioAEditar == null)
                    return false;

                usuarioAEditar.UsuarioId = creacionPruebaLabDTO.Cedula;
                usuarioAEditar.Nombre = creacionPruebaLabDTO.Nombre;
                usuarioAEditar.Apellido = creacionPruebaLabDTO.Apellido;
                usuarioAEditar.Username = creacionPruebaLabDTO.UserName;
                usuarioAEditar.Password = HashPassword(creacionPruebaLabDTO.Password);
                usuarioAEditar.Telefono = creacionPruebaLabDTO.Telefono;
                usuarioAEditar.Email = creacionPruebaLabDTO.Email;

                await _usuarioRepositorio.Editar(usuarioAEditar);

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
            var usuarios = await _usuarioRepositorio.Consultar().Include(u => u.Role).ToListAsync();

            return usuarios.Select(u => new UsuarioDTO()
            {
                Cedula = u.UsuarioId,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                UserName = u.Username,
                NombreRol = u.Role.NombreRol,
                Telefono = u.Telefono,
                Email = u.Email
            }).ToList();
        }


        // Encrypt user password
        private static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var randomGenerator = RandomNumberGenerator.Create())
            {
                randomGenerator.GetBytes(salt);
            }
            var rfcPassword = new Rfc2898DeriveBytes(password, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassword.GetBytes(20);

            byte[] passwordHash = new byte[36];
            Array.Copy(salt, 0, passwordHash, 0, 16);
            Array.Copy(rfcPasswordHash, 0, passwordHash, 16, 20);
            return Convert.ToBase64String(passwordHash);
        }
    }
}
