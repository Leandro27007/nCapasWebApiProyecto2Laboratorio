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
        Task<Recibo> GuardarReciboAsync(Recibo modelo);
        Task<bool> ReembolsarReciboAsync();
        Task<List<Recibo>> ListarRecibosAsync(int paginaActual, int? cantidadRegistros);
        Task<Recibo?> BuscarReciboAsync(int idRecibo);

    }
}
