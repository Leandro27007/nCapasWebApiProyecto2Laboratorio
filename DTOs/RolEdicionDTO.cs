using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class RolEdicionDTO
    {
        [Required]
        public int IdRol { get; set; }
        [Required]
        public string NombreRol { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
