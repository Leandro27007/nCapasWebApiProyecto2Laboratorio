using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class GenerarReciboDTO
    {
        [Required]
        public string IdCajero { get; set; }
        [Required]
        public string NombreCliente { get; set; }
        [Required]
        public string ApellidoCliente { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Cedula { get; set; }
        public List<PruebaReciboDTO> Pruebas { get; set; }
    }
}
