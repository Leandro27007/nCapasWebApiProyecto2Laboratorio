using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class PruebaReciboDTO
    {
        [Required]
        public int IdPruebaLab { get; set; }
        public string? NombrePrueba { get; set; }
        public decimal Precio { get; set; }
    }
}