using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using Proyecto2Laboratorio.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Implementaciones
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepositorio _turnoRepositorio;
        public TurnoService(ITurnoRepositorio turnoRepositorio)
        {
            this._turnoRepositorio = turnoRepositorio;
        }

        public async Task<bool> Atender(string idTurno)
        {
            //Obtengo el turno de la base de datos que su id sea igual a mi parametro
            var turno = await _turnoRepositorio.Obtener(t => t.TurnoId == idTurno);

            //Si existe le cambio el estado a 2, o sea atendido.
            if (turno != null)
            {
                turno.EstadoTurnoId = 2;
                await _turnoRepositorio.Editar(turno);

                return true;
            }
            return false;
        }

        public async Task<bool> CancelarTurno(string idTurno)
        {
            //Obtengo el turno de la base de datos que su id sea igual a mi parametro
            var turno = await _turnoRepositorio.Obtener(t => t.TurnoId == idTurno);

            //Si existe le cambio el estado a 3, o sea cancelado.
            if (turno != null)
            {
                turno.EstadoTurnoId = 3;
                await _turnoRepositorio.Editar(turno);

                return true;
            }
            return false;
        }

        public async Task<Turno> GenerarTurno(List<PruebaDeLaboratorio> pruebaDeLaboratorios)
        {
            var consulta = _turnoRepositorio.Consultar().Result;
            string? ultimoTurno = consulta.Select(d => d.TurnoId).LastOrDefault();
            if (ultimoTurno == null)
                ultimoTurno = "0";

            int numeroTurno = FormatearNumeroTurnoId(ultimoTurno);
            numeroTurno += 1;

            //Creo y asigno pruebasLaboratorio en un objeto para el turno que se va a crear.
            var turnoPruebaLab = new List<TurnoPruebaDeLaboratorio>();
            for (int i = 0; i <= turnoPruebaLab.Count; i++)
            {
                turnoPruebaLab[i].PruebaDeLaboratorioId = pruebaDeLaboratorios[i].PruebaDeLaboratorioId;
                turnoPruebaLab[i].TurnoId += numeroTurno.ToString();
            }

            //mando a crear el turno en la base de datos y lo retorno
            return await _turnoRepositorio.Crear(new Turno()
            {
                TurnoId = numeroTurno.ToString(),
                EstadoTurnoId = 1,
                turnoPruebaDeLaboratorios = turnoPruebaLab
            });

        }

        public async Task<bool> ResetearTurnos()
        {
            var turnos = await _turnoRepositorio.ObtenerTodo();
            if (turnos != null)
            {
                foreach (var item in turnos)
                {
                   await _turnoRepositorio.Eliminar(item);
                }
                return true;
            }
            return false;
        }

        private int FormatearNumeroTurnoId(string idTurno = "0")
        {
            string numeroDeIdTurno = Regex.Replace(idTurno, "T-", "").Trim();
            int numeroTurno = 0;
            int.TryParse(numeroDeIdTurno, out numeroTurno);

            return numeroTurno;
        }


    }
}
