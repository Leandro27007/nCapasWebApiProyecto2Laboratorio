using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.DAL.Repositorio.Interfaces
{
    public interface IRepositorioGenerico<T> 
    {
        Task<T?> Obtener(Expression<Func<T, bool>> filtro);
        Task<IEnumerable<T>?> ObtenerTodo(Expression<Func<T, bool>>? filtro);
        T Crear(T Modelo);
        Task<bool> Editar (T Modelo);
        Task<bool> Eliminar(T Modelo);
        Task<IQueryable<T>> Consultar(Expression<Func<T, bool>>? filtro = null);
        Task<bool> SaveChangeAsync();
    }
}
