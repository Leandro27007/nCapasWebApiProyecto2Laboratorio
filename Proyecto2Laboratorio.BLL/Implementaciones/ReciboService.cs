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
    public class ReciboService : IReciboService
    {

        private readonly IReciboRepositorio _reciboRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IPruebaDeLaboratorioRepositorio _pruebaLabRepositorio;
        public ReciboService(IReciboRepositorio reciboRepositorio,
                            IClienteRepositorio clienteRepositorio,
                            IPruebaDeLaboratorioRepositorio pruebaLabRepositorio)
        {
            this._reciboRepositorio = reciboRepositorio;
            this._clienteRepositorio = clienteRepositorio;
            this._pruebaLabRepositorio = pruebaLabRepositorio;
        }


        public async Task<ReciboDTO?> GenerarReciboAsync(GenerarReciboDTO reciboDTO)
        {

            //LOGICA PARA VALIDAR
            //*********************

            //Busca un cliente que su cedula sea igual a la que se recibio en el DTO desde el controlador.
            var cliente = await _clienteRepositorio.Obtener(c => c.Cedula == reciboDTO.Cedula);

            //Mando a registrar un cliente si no existe en la base de datos.
            Cliente clienteParaAgregar = new Cliente();
            if (cliente == null)
            {
                clienteParaAgregar.Nombre = reciboDTO.NombreCliente;
                clienteParaAgregar.Telefono = reciboDTO.Telefono;
                clienteParaAgregar.Apellido = reciboDTO.ApellidoCliente;
                clienteParaAgregar.Email = reciboDTO.Email;
                clienteParaAgregar.FechaRegistro = DateTime.Now;
                clienteParaAgregar.Cedula = reciboDTO.Cedula;

                //Mando a registrar este cliente que se mapeao
                //var clienteAgregado = _clienteRepositorio.Crear(clienteParaAgregar, GuardarCambios: false);
            }

            //Mapear el recibo.
            Recibo reciboParaAgregar = new Recibo();
            reciboParaAgregar.Usuario = null;
            reciboParaAgregar.Cliente = null;// Para que el ORM no intente agregar un usuario al intentar agregar un recibo
            reciboParaAgregar.UsuarioId = reciboDTO.IdCajero;
            reciboParaAgregar.Fecha = DateTime.Now;
            reciboParaAgregar.Estado = "Pendiente";

            if (cliente != null)
            {
                reciboParaAgregar.ClienteId = cliente.ClienteId;
            }
            else
            {
                reciboParaAgregar.Cliente = clienteParaAgregar;
            }

            reciboParaAgregar.NCF = "79835465465";

            var reciboAgregado = await _reciboRepositorio.Crear(reciboParaAgregar);



            //Mapeo las pruebas de laboratorio
            List<PruebaDeLaboratorioRecibo> pruebaDeLaboratorioRecibo = new();


            foreach (var item in reciboDTO.Pruebas)
            {

                decimal? precioPrueba = await _pruebaLabRepositorio.Consultar().Where(x => x.PruebaDeLaboratorioId == item.IdPruebaLab)
                                                                          .Select(p => p.Precio)
                                                                          .FirstOrDefaultAsync();
                if (precioPrueba == null)
                    continue;

                pruebaDeLaboratorioRecibo.Add(new PruebaDeLaboratorioRecibo()
                {
                    PruebaDeLaboratorioId = item.IdPruebaLab,
                    ReciboId = reciboAgregado.ReciboId,
                    Precio = (decimal)precioPrueba
                });
            }

            reciboAgregado.PruebasDeLaboratorioRecibo.AddRange(pruebaDeLaboratorioRecibo);
            bool seEdito = await _reciboRepositorio.Editar(reciboAgregado);


            return await BuscarReciboAsync(reciboAgregado.ReciboId);
        }

        public async Task<ReciboDTO?> BuscarReciboAsync(int idRecibo)
        {
            var recibo = await _reciboRepositorio.Consultar()
                                                 .Include(r => r.Usuario)
                                                 .Include(r => r.Cliente)
                                                 .Include(r => r.PruebasDeLaboratorioRecibo)
                                                 .ThenInclude(plr => plr.PruebaDeLaboratorio)
                                                 .Where(r => r.ReciboId == idRecibo).FirstOrDefaultAsync();

            ReciboDTO reciboDto = new();

            reciboDto.IdRecibo =  recibo.ReciboId;
            reciboDto.NombreCajero = recibo.Usuario.Nombre;
            reciboDto.NombreCliente = recibo.Cliente.Nombre;
            reciboDto.Estado = recibo.Estado;
            reciboDto.Pruebas = recibo.PruebasDeLaboratorioRecibo.Select(p => new PruebaReciboDTO()
            {
                IdPruebaLab = p.PruebaDeLaboratorio.PruebaDeLaboratorioId,
                NombrePrueba = p.PruebaDeLaboratorio.Nombre,
                Precio = p.Precio
            }).ToList();
            reciboDto.Total = recibo.PruebasDeLaboratorioRecibo.Select(p => p.PruebaDeLaboratorio.Precio).Sum();

            return reciboDto;

        }

        public async Task<string?> ObtenerEstadoReciboAsync(int idRecibo)
        {
            string? mensajeRetorno = "No se encontro el recibo";

            var recibo = await _reciboRepositorio.Consultar(r => r.ReciboId == idRecibo).FirstOrDefaultAsync();

            if (recibo != null)
                mensajeRetorno = $"El estado actual del recibo es: {recibo.Estado}";

            return mensajeRetorno;
        }

        public async Task<List<ReciboDTO>?> ListarRecibosAsync(int paginaActual = 1)
        {
            var recibo = await _reciboRepositorio.Consultar()
                                                 /*.Skip(paginaActual + 1)
                                                 .Take(10)*/
                                                 .Include(r => r.Usuario)
                                                 .Include(r => r.Cliente)
                                                 .Include(r => r.PruebasDeLaboratorioRecibo)
                                                 .ThenInclude(plr => plr.PruebaDeLaboratorio)
                                                 .ToListAsync();

            List<ReciboDTO>? reciboDTOs = new();

            for (int i = 0; i < recibo.Count; i++)
            {

                ReciboDTO reciboDto = new();
                reciboDto.IdRecibo = recibo[i].ReciboId;
                reciboDto.NombreCajero = recibo[i].Usuario.Nombre;
                reciboDto.NombreCliente = recibo[i].Cliente.Nombre;
                reciboDto.Estado = recibo[i].Estado;
                reciboDto.Pruebas = recibo[i].PruebasDeLaboratorioRecibo.Select(p => new PruebaReciboDTO()
                {
                    IdPruebaLab = p.PruebaDeLaboratorio.PruebaDeLaboratorioId,
                    NombrePrueba = p.PruebaDeLaboratorio.Nombre,
                    Precio = p.Precio
                }).ToList();
                reciboDto.Total = recibo[i].PruebasDeLaboratorioRecibo.Select(p => p.PruebaDeLaboratorio.Precio).Sum();

                reciboDTOs.Add(reciboDto);
            }


            return reciboDTOs;
        }

        //TODO: Implementar
        public async Task<bool> ReembolsarReciboAsync(int idRecibo, string notaDeReembolso)
        {
            var recibo =  await _reciboRepositorio.Obtener(r => r.ReciboId == idRecibo);

            if (recibo != null && recibo.Estado == "Pendiente")
            {
                recibo.Estado = "Reembolsado";
                recibo.NotaDeModificacion = notaDeReembolso;
                recibo.IdUltimoUsuarioQueModifico = 402;
                await _reciboRepositorio.Editar(recibo);
                return true;
            }
            return false;

        }



    }
}
