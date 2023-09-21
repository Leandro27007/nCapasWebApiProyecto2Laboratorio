using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class Recibo
    {
        [Key]
        public int ReciboId { get; set; }
        [Required]
        public string NCF { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha { get; set; }

        public Cliente Cliente { get; set; }
        [ForeignKey("Cliente")]
        public string CedulaCliente { get; set; }

        public Medico Medico { get; set; }
        [ForeignKey("Medico")]
        public string CedulaMedico { get; set }

        [ForeignKey("Usuario")]
        public Usuario Usuario { get; set; }
        public string CedulaUsuario { get; set; }

        [ForeignKey("EstadoRecibo")]
        public EstadoRecibo EstadoRecibo { get; set; }
        public int EstadoReciboId { get; set; }

        public List<PruebaDeLaboratorio> PruebasDeLaboratorio { get; set; }

    }
}
