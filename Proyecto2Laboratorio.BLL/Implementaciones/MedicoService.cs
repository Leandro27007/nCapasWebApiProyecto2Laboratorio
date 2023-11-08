using DTOs;
using Microsoft.EntityFrameworkCore;
using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.BLL.Utilidades;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Implementaciones
{
    public class MedicoService : IMedicoService
    {
        private readonly IClienteRepositorio _clienteRespositorio;
        private readonly IReciboRepositorio _reciboRespositorio;
        public MedicoService(IClienteRepositorio clienteRespositorio, IReciboRepositorio reciboRespositorio)
        {
            this._clienteRespositorio = clienteRespositorio;
            this._reciboRespositorio = reciboRespositorio;
        }

        public async Task<PacienteDTO?> BuscarPaciente(int IdRecibo)
        {
            try
            {
                var cliente = await _clienteRespositorio.Consultar()
                                              .Include(c => c.Recibos.Where(r => r.ReciboId == IdRecibo))
                                              .ThenInclude(r => r.PruebasDeLaboratorioRecibo)
                                              .ThenInclude(r => r.PruebaDeLaboratorio)
                                              .FirstOrDefaultAsync(c => c.Recibos.Where(r => r.ReciboId == IdRecibo).First().ReciboId == IdRecibo);

                if (cliente != null)
                {

                    return new PacienteDTO()
                    {
                        IdRecibo = cliente.Recibos.First().ReciboId,
                        NombreCliente = cliente.Nombre,
                        ApellidoCliente = cliente.Apellido,
                        Estado = cliente.Recibos.First().Estado,
                        Pruebas = cliente.Recibos.First().PruebasDeLaboratorioRecibo.ToList()
                                                                                    .Select(p => new PruebaPacienteDTO()
                                                                                    {
                                                                                        IdPruebaLab = p.PruebaDeLaboratorioId,
                                                                                        NombrePrueba = p.PruebaDeLaboratorio.Nombre
                                                                                    }).ToList()
                    };


                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  async Task<List<string>?> ObtenerEstadosDeRecibo()
        {

            return EstadosRecibo.estados.Where(e => e != EstadosRecibo.REEMBOLSADO).ToList();
        }

            public async Task<bool> CambiarEstadoDeRecibo(int idRecibo, string nuevoEstado)
        {
            try
            {
                //Verifico si el parametro nuevoEstado existe segun las reglas de negocio
                string? estado = EstadosRecibo.estados.Find(c => c == nuevoEstado);
                if (estado == null || estado == EstadosRecibo.REEMBOLSADO)
                    return false;

                //Busco el recibo y cambio su estado, si no existe retorno false
                Recibo? recibo = await _reciboRespositorio.Obtener(r => r.ReciboId == idRecibo);
                if (recibo == null)
                    return false;


                recibo.Estado = estado;

                await _reciboRespositorio.Editar(recibo);
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<PacienteDTO>?> ListarPacientesEnEspera()
        {
            try
            {
                var cliente = await _clienteRespositorio.Consultar(c => c.Recibos.Count() > 0 && c.Recibos.Where(r => r.Estado == EstadosRecibo.PENDIENTE).Count() > 0)
                                              .Include(c => c.Recibos.Where(r => r.Estado == EstadosRecibo.PENDIENTE))
                                              .ThenInclude(r => r.PruebasDeLaboratorioRecibo)
                                              .ThenInclude(r => r.PruebaDeLaboratorio)
                                              .ToListAsync();


                if (cliente != null)
                {

                   var pacienteDTO = cliente.Select(c => new PacienteDTO()
                    {
                        IdRecibo = c.Recibos.First().ReciboId,
                        NombreCliente = c.Nombre,
                        ApellidoCliente = c.Apellido,
                        Estado = c.Recibos.First().Estado,
                        Pruebas = c.Recibos.First().PruebasDeLaboratorioRecibo.ToList()
                                                                                    .Select(p => new PruebaPacienteDTO()
                                                                                    {
                                                                                        IdPruebaLab = p.PruebaDeLaboratorioId,
                                                                                        NombrePrueba = p.PruebaDeLaboratorio.Nombre
                                                                                    }).ToList()
                    }).ToList();

                    return pacienteDTO;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
