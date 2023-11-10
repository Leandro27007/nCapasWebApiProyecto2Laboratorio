using DTOs;
using Microsoft.EntityFrameworkCore;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Implementaciones
{
    public class ReporteService : IReporteService
    {
        private IReciboRepositorio _reciboRepositorio;
        public ReporteService(IReciboRepositorio reciboRepositorio)
        {
            this._reciboRepositorio = reciboRepositorio;
        }
        public async Task<ReporteDTO> ObtenerReportesVentas(DateTime FechaInicio, DateTime FechaFinal)
        {
            var recibos = await _reciboRepositorio.Consultar()
                                             .Where(r => r.Fecha >= FechaInicio && r.Fecha <= FechaFinal.AddDays(1))
                                             .Include(r => r.Cliente)
                                             .Include(r => r.Usuario)
                                             .Include(r => r.PruebasDeLaboratorioRecibo)
                                             .ThenInclude(plr => plr.PruebaDeLaboratorio).ToListAsync();



            ReporteDTO reporte = new()
            {
                Recibos = recibos.Select(r => new ReciboDTO()
                {
                    IdRecibo = r.ReciboId,
                    NombreCliente = r.Cliente.Nombre,
                    NombreCajero = r.Usuario.Nombre,
                    Estado = r.Estado,
                    Fecha = r.Fecha,
                    Pruebas = r.PruebasDeLaboratorioRecibo.Select(plr => new PruebaReciboDTO()
                    {
                        IdPruebaLab = plr.PruebaDeLaboratorioId,
                        NombrePrueba = plr.PruebaDeLaboratorio.Nombre,
                        Precio = plr.Precio
                    }).ToList(),
                    Total = r.PruebasDeLaboratorioRecibo.Select(plr => plr.PruebaDeLaboratorio.Precio).Sum()
                }).ToList(),
                FechaDeGeneracion = DateTime.Now,
                TotalVenta = 0m
            };

            foreach (var item in reporte.Recibos)
            {
                if (item.Estado.Trim() == "Reembolsado")
                {
                    continue;
                }
                reporte.TotalVenta += item.Total;
            }

            return reporte;
        }
    }
}
