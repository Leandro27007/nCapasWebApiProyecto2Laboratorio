using System;
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
        [StringLength(15)]
        public string TurnoId { get; set; } = "T-"; //Todos los turno empiezan con ese formato seguido del numero
        public List<TurnoPruebaDeLaboratorio> turnoPruebaDeLaboratorios { get; set; } = new();
        public DateTime FechaRegistro { get; set; }
        [StringLength(50)]
        public string EstadoTurno { get; set; }

    }
}