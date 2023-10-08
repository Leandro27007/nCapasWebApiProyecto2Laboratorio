﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class Turno
    {
        [Key]
        public string TurnoId { get; set; } = "T-"; //Todos los turno empiezan con ese formato seguido del numero
        public List<TurnoPruebaDeLaboratorio> turnoPruebaDeLaboratorios { get; set; } = new();
        public string EstadoTurno { get; set; }

    }
}