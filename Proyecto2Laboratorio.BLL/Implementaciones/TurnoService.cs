using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Implementaciones
{
    public class TurnoService : ITurnoService
    {
        public async Task<bool> CancelarTurno(string idTurno)
        {
            throw new NotImplementedException();
        }

        public Task<Turno> GenerarTurno(List<PruebaDeLaboratorio> pruebaDeLaboratorios)
        {
            throw new NotImplementedException();
        }
    }
}
