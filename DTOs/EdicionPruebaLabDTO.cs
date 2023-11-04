using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EdicionPruebaLabDTO
    {
        [Required]
        public int IdPruebaLab { get; set; }
        [Required]
        public string NombrePrueba { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public decimal Precio { get; set; }
    }
}
