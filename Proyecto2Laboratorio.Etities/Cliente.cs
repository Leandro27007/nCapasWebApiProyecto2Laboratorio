using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.Etities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string ApellidoCliente { get; set; } = null!;
        public string? TelefonoCliente { get; set; }
        public string CedulaCliente { get; set; } = null!;
        public string? EmailCliente { get; set; }
    }
}
