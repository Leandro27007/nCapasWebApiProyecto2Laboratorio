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
<<<<<<< HEAD
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
=======
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string CedulaCliente { get; set; }
        public string? EmailCliente { get; set; }

>>>>>>> dcced03a846c5c72d1faf7b596b73d9cd28ddae4
    }
}
