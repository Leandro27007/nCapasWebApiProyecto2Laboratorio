﻿using DTOs;
using Proyecto2Laboratorio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Interfaces
{
    public interface ITurnoService
    {
        Task<List<TurnoDTO>> ListarTurnosPendientes();
        Task<List<TurnoDTO>> HistorialTurnos();
        Task<Turno> GenerarTurno(GenerarTurnoDTO Turno);
        Task<bool> CancelarTurno(string idTurno);
        Task<bool> Atender(string idTurno);
        Task<bool> ResetearTurnos();
    }
}
