using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class Rol
    {
        [Key] // un comentario
        public int RolId { get; set; }
        [Required]
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
