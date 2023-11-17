using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class UsuarioEdicionDTO
    {
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public int RolId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string? Email { get; set; }
        public string? Estado { get; set; }
    }
}
