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
        //comentario

        //Otro Comentario

        //Tercer comentario

        [Key]
        public int ReciboId { get; set; }
        [Required]
        public string NCF { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha { get; set; }

        public Cliente Cliente { get; set; }
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public EstadoRecibo EstadoRecibo { get; set; }
        [ForeignKey("EstadoRecibo")]
        public int EstadoReciboId { get; set; }

        public List<PruebaDeLaboratorioRecibo> PruebasDeLaboratorio { get; set; } = new List<PruebaDeLaboratorioRecibo>();
        public List<UsuarioRecibo> UsuarioRecibos { get; set; } = new List<UsuarioRecibo>();

    }
}
