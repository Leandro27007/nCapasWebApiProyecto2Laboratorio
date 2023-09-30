﻿using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Interfaces
{
    public interface ITurnoService
    {
        Task<Turno> GenerarTurno(List<PruebaDeLaboratorio> pruebaDeLaboratorios);
        Task<bool> CancelarTurno(string idTurno);


    }
}