using DTOs;
using Microsoft.EntityFrameworkCore;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using Proyecto2Laboratorio.Entities;
using System;
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
                idPruebaLab = pl.PruebaDeLaboratorioId,
                NombrePrueba = pl.Nombre,
                Precio = pl.Precio
            }).ToListAsync();

            return pruebasLab;
        }

        public async Task<PruebaLabDTO?> CrearPruebaLabAsync(CreacionPruebaLabDTO creacionPruebaLabDTO)
        {
            try
            {
                var resultado = await _pruebaDeLaboratorioRepositorio.Crear(new PruebaDeLaboratorio()
                {
                    Nombre = creacionPruebaLabDTO.NombrePrueba,
                    Descripcion = creacionPruebaLabDTO.Descripcion,
                    Precio = creacionPruebaLabDTO.Precio,
                    Recibos = null!,
                    turnoPruebaDeLaboratorios = null!
                });

                PruebaLabDTO pruebaLabDTO = new PruebaLabDTO()
                {
                    idPruebaLab = resultado.PruebaDeLaboratorioId,
                    NombrePrueba = resultado.Nombre,
                    Precio = resultado.Precio
                };

                return pruebaLabDTO;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool?> EditarPruebaLabAsync(EdicionPruebaLabDTO creacionPruebaLabDTO)
        {
            try
            {

                var pruebaLab = await _pruebaDeLaboratorioRepositorio.Obtener(pl => pl.PruebaDeLaboratorioId == creacionPruebaLabDTO.IdPruebaLab);

                if (pruebaLab != null)
                {
                    pruebaLab.PruebaDeLaboratorioId = creacionPruebaLabDTO.IdPruebaLab;
                    pruebaLab.Nombre = creacionPruebaLabDTO.NombrePrueba;
                    pruebaLab.Descripcion = creacionPruebaLabDTO.Descripcion;
                    pruebaLab.Precio = creacionPruebaLabDTO.Precio;

                    var resultado = await _pruebaDeLaboratorioRepositorio.Editar(pruebaLab);

                    return resultado;
                }
                else
                {

                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool?> EliminarPruebaLabAsync(int IdPrueba)
        {
            try
            {
                var pruebaLab = await _pruebaDeLaboratorioRepositorio.Obtener(pl => pl.PruebaDeLaboratorioId == IdPrueba);

                if (pruebaLab != null)
                {

                    var resultado = await _pruebaDeLaboratorioRepositorio.Eliminar(pruebaLab);

                    return resultado;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
