using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2Laboratorio.Entities
{
    public class Usuario
    {
        [Key]
        [StringLength(15)]
        public string UsuarioId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Telefono { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        public string? Estado { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
        public List<Recibo> Recibos { get; set; }
        public Rol Role { get; set; }
        [ForeignKey("Rol")]
        public int RolId { get; set; }

    }
}
