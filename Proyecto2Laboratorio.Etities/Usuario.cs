using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Etities
{
    public class Usuario
    {
        [Key]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string? Email { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
