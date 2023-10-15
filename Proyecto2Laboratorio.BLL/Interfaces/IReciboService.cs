using DTOs;
using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Interfaces
{
    public interface IReciboService
    {
        Task<ReciboDTO?> GenerarReciboAsync(GenerarReciboDTO modelo);
        Task<bool> ReembolsarReciboAsync(int IdRecibo, string notaDeReembolso);
        Task<List<ReciboDTO>?> ListarRecibosAsync(int paginaActual = 1);
        Task<ReciboDTO?> BuscarReciboAsync(int idRecibo);
        Task<string?> ObtenerEstadoReciboAsync(int idRecibo);
    }
}
