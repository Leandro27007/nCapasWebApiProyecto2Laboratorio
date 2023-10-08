
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




        public async Task<IQueryable<T>> Consultar(Expression<Func<T, bool>>? filtro = null)
        {

            IQueryable<T> consulta;

            if (filtro == null)
            {
                consulta = dbSet.AsQueryable();
            }
            else
            {
                consulta = dbSet.Where(filtro).AsQueryable();
            }

            return  consulta;
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

        public async Task<bool> Editar(T Modelo, bool? GuardarCambios = true)
        {
            dbSet.Update(Modelo);
            return await this.SaveChangeAsync();
        }

        public async Task<bool> Eliminar(T Modelo)
        {
            dbSet.Remove(Modelo);
            return await this.SaveChangeAsync();
        }

        public async Task<T?> Obtener(Expression<Func<T, bool>> filtro)
        {

            return await dbSet.FirstOrDefaultAsync();
        }

        public async Task<List<T>?> ObtenerTodo(Expression<Func<T, bool>>? filtro = null)
        {
            return await dbSet.ToListAsync();
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
