using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class TurnoPruebaDeLaboratorio
    {
        [Key]
        public int TurnoPruebaDeLaboratorioId { get; set; }

        public PruebaDeLaboratorio PruebaDeLaboratorio { get; set; }
        public int PruebaDeLaboratorioId { get; set; }

        public Turno Turno { get; set; }
        public string TurnoId { get; set; } = "T-";

    }
}
