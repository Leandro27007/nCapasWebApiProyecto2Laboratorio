﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReporteDTO
    {
        public DateTime FechaDeGeneracion { get; set; }
        public List<ReciboDTO> Recibos { get; set; }
        public decimal? TotalVenta { get; set; }
    }
}