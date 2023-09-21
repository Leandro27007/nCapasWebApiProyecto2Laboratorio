using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class EstadoRecibo
    {
        [Key]
        public int EstadoReciboId { get; set; }
        [Required]
        public string NombreEstado { get; set; }
        public string DescripcionEstado { get; set; }

        public List<Recibo> Recibos { get; set; }
    }
}
