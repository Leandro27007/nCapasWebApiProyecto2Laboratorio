using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Entities
{
    public class UsuarioRecibo
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        public Usuario Usuario { get; set; }
        public string Cedula { get; set; }

        public Recibo Recibo { get; set; }
        public string ReciboId { get; set; }

    }
}
