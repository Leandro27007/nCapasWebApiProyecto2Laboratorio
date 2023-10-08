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
        Task<List<T>?> ObtenerTodo(Expression<Func<T, bool>>? filtro = null);
        Task<T> Crear(T Modelo, bool? GuardarCambios = true);
        Task<bool> Editar(T Modelo, bool? GuardarCambios = true);
        Task<bool> Eliminar(T Modelo);
        Task<IQueryable<T>> Consultar(Expression<Func<T, bool>>? filtro = null);
        Task<bool> SaveChangeAsync();
    }
}
