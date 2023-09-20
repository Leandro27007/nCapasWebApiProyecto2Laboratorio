using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Etities
{
    public class Recibo
    {
        [Key]
        public int ReciboID { get; set; }
        public string NCF { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha { get; set; }
    }
}
