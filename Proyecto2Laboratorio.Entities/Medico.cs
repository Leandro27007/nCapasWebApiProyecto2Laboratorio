using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Proyecto2Laboratorio.Entities
{
    public class Medico
    {
        [Key]
        public string Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string? Email { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }



    }
}
