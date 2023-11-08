using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Interfaces
{
    public interface IReporteService
    {
        Task<ReporteDTO> ObtenerReportesVentas(DateTime FechaInicio, DateTime FechaFinal);

    }
}
