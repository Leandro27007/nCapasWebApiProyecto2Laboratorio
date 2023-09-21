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
        public string Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }

    }
}
