using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Etities
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public string? Sucursal { get; set; }
        public decimal? Descuento { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdMedico { get; set; }
        public int IdEstado { get; set; }
        public byte[] FechaFactura { get; set; } = null!;

    }
}
