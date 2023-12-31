﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }
        [Required]
        [StringLength(50)]
        public string NombreRol { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<Usuario> Usuarios { get; set; }

    }
}
