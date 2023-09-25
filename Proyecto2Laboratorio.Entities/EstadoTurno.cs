using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class EstadoTurno
    {
        [Key]
        public int EstadoTurnoId { get; set; }
        public string NombreEstado { get; set; }

        public Turno Turno { get; set; }

    }
}
