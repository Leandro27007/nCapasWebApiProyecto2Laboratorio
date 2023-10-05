using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Proyecto2Laboratorio.Entities
{
    public class Usuario
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

        public List<UsuarioRecibo> Recibos { get; set; } = null!;
        
    }
}
