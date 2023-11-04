using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class UsuarioCreacionDTO
    {
        [Required]
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

    }
}
