using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.DAL.Repositorio.Interfaces
{
    public interface ITurnoRepositorio : IRepositorioGenerico<Turno>
    {
        Task<string> ObtenerSiguienteTurno();
    }
}
