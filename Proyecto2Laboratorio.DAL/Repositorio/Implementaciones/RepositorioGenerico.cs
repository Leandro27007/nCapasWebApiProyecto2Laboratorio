
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.DAL.Repositorio.Implementaciones
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public RepositorioGenerico(ApplicationDbContext db)
        {
            _db = db;

            this.dbSet = _db.Set<T>();
        }




        public Task<IQueryable<T>> Consultar(Expression<Func<T, bool>>? filtro = null)
        {

            //LOGICA PARA CONSULTAR

            throw new NotImplementedException();
        }

        public async Task<T> Crear(T modelo, bool? GuardarCambios = true)
        {
            //LOGICA PARA CREAR
            await dbSet.AddAsync(modelo);


            if (GuardarCambios == true)
            {
               await this.SaveChangeAsync();
                return modelo;
            }

            return null;
        }

        public Task<bool> Editar(T Modelo, bool? GuardarCambios = true)
        {

            //LOGICA PARA EDITAR CON GENERIC

            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(T Modelo)
        {
            //LOGICA PARA ELIMINAR CON GENERIC

            throw new NotImplementedException();
        }

        public Task<T?> Obtener(Expression<Func<T, bool>> filtro)
        {

            //LOGICA PARA OBTENER CON GENERIC

            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>?> ObtenerTodo(Expression<Func<T, bool>>? filtro)
        {

            //LOGICA PARA OBTENER TODO

            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangeAsync()
        {

            //LOGICA PARA HACER UN GUARDADO EN LA BASE DE DATOS
            try
            {
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
