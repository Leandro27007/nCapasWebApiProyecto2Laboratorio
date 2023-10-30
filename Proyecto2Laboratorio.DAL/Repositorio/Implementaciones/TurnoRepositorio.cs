using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using Proyecto2Laboratorio.DAL.Utilidades;
using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.DAL.Repositorio.Implementaciones
{
    public class TurnoRepositorio : RepositorioGenerico<Turno>, ITurnoRepositorio
    {
        private ApplicationDbContext _db;
        public TurnoRepositorio(ApplicationDbContext db) : base(db) 
        {
            this._db = db;
        }
        /// <summary>
        /// Retorna un incremento del ultimo idTurno del repositorio, retorna el suigiente id.
        /// </summary>
        /// <returns></returns>
        public async Task<string> ObtenerSiguienteTurno()
        {
            string siguienteTurnoId =  await _db.turno.ObtenerSiguienteId();

            return siguienteTurnoId;
        }
    }
}
