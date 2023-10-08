using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class PruebaDeLaboratorioRecibo
    {
        [Key]
        [Column(Order =1)]
        public int Id { get; set; }
        public decimal Precio { get; set; }
        public PruebaDeLaboratorio PruebaDeLaboratorio { get; set; } = new();
        public int PruebaDeLaboratorioId { get; set; }
        public Recibo Recibo { get; set; } = new();
        public int ReciboId { get; set; }


    }
}
