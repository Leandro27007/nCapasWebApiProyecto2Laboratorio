using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class Cliente
    {

        [Key]
        public int ClienteId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        [StringLength(15)]
        public string? Telefono { get; set; }
        [StringLength(15)]
        public string? Cedula { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        public List<Recibo> Recibos { get; set; }
    }
}
