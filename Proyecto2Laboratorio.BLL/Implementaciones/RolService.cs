using DTOs;
using Microsoft.EntityFrameworkCore;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Implementaciones
{
    public class RolService : IRolService
    {
        private readonly IRolRepositorio _rolRepositorio;
        public RolService(IRolRepositorio rolRepositorio)
        {
            this._rolRepositorio = rolRepositorio;    
        }
        public async Task<RolObtencionDTO> CrearRol(RolCreacionDTO rolCreacion)
        {

            Rol rol = new Rol()
            {
                NombreRol = rolCreacion.NombreRol,
                Descripcion = rolCreacion.Descripcion,
                FechaRegistro = DateTime.Now
            };

            await _rolRepositorio.Crear(rol);

            return new RolObtencionDTO()
            {
                IdRol = rol.RolId,
                NombreRol = rol.NombreRol,
                Descripcion = rol.Descripcion
            };
        }

        public async Task<bool> EditarRol(RolEdicionDTO rolEdicion)
        {
            try
            {
                Rol rol = new Rol()
                {
                    RolId = rolEdicion.IdRol,
                    NombreRol = rolEdicion.NombreRol,
                    Descripcion = rolEdicion.Descripcion
                };

                await _rolRepositorio.Editar(rol);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> Eliminar(int idRol)
        {
            var rolParaEliminar = await _rolRepositorio.Obtener(r => r.RolId == idRol);

            if (rolParaEliminar == null)
                return false;

            try
            {
                await _rolRepositorio.Eliminar(rolParaEliminar);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<RolObtencionDTO>> ListarRoles()
        {
            var roles = await _rolRepositorio.Consultar().ToListAsync();

            return roles.Select(r => new RolObtencionDTO()
            {
                IdRol = r.RolId,
                NombreRol = r.NombreRol,
                Descripcion = r.Descripcion
            }).ToList();
        }
    }
}
