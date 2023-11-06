using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2Laboratorio.Entities
{
    public class Recibo
    {
        [Key]
        public int ReciboId { get; set; }
        [Required]
        [StringLength(50)]
        public string NCF { get; set; }
        public decimal? Descuento { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; } = new Cliente();
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        [StringLength(50)]
        public string Estado { get; set; }
        public int? IdUltimoUsuarioQueModifico { get; set; }
        [StringLength(50)]
        public string? NotaDeModificacion { get; set; }
        public List<PruebaDeLaboratorioRecibo> PruebasDeLaboratorioRecibo { get; set; } = new List<PruebaDeLaboratorioRecibo>();
        public virtual Usuario Usuario { get; set; } = new Usuario();
        [ForeignKey("Usuario")]
        [StringLength(15)]
        public string UsuarioId { get; set; }
    }
}
