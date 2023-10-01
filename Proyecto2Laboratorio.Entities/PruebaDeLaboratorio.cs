using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class PruebaDeLaboratorio
    {
        [Key]
        public int PruebaDeLaboratorioId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public List<PruebaDeLaboratorioRecibo> Recibos { get; set; }

        public List<TurnoPruebaDeLaboratorio> turnoPruebaDeLaboratorios { get; set; } = new();

    }
}
