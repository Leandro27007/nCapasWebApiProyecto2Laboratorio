using DTOs;
using Microsoft.EntityFrameworkCore;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Implementaciones
{


    public class PruebaLabService : IPruebasLabService
    {
        private readonly IPruebaDeLaboratorioRepositorio _pruebaDeLaboratorioRepositorio;

        public PruebaLabService(IPruebaDeLaboratorioRepositorio pruebaDeLaboratorioRepositorio)
        {
            _pruebaDeLaboratorioRepositorio = pruebaDeLaboratorioRepositorio;
        }

        public async Task<IEnumerable<PruebaLabDTO>?> ListarPruebas()
        {

            var pruebasLab = await _pruebaDeLaboratorioRepositorio.Consultar().Select(pl => new PruebaLabDTO()
            {
                IdPrueba = pl.PruebaDeLaboratorioId,
                NombrePrueba = pl.Nombre,
                Precio = pl.Precio
            }).ToListAsync();

            return pruebasLab;
        }
    }
}
