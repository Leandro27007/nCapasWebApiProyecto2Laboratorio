using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class Permisos
    {
        //Comit a master
        //Comit a master2

        [Key]
        public int PermisoId { get; set; }
        [Required]
        public string NombrePermiso { get; set; }
        public string Descripcion { get; set; }
    }
}
