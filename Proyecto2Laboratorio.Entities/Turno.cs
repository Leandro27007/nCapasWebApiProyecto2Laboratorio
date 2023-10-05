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
        public string TurnoId { get; set; } = null!; 
        public List<TurnoPruebaDeLaboratorio> turnoPruebaDeLaboratorios { get; set; } = new();

        public EstadoTurno EstadoTurno { get; set; }
        [ForeignKey("EstadoTurno")]
        public int EstadoTurnoId { get; set; }
    }
}
