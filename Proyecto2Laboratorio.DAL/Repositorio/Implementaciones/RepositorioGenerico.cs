
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
        public Task<IQueryable<T>> Consultar(Expression<Func<T, bool>>? filtro = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> Crear(T Modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(T Modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(T Modelo)
        {
            throw new NotImplementedException();
        }

        public Task<T?> Obtener(Expression<Func<T, bool>> filtro)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>?> ObtenerTodo(Expression<Func<T, bool>>? filtro)
        {
            throw new NotImplementedException();
        }
    }
}
