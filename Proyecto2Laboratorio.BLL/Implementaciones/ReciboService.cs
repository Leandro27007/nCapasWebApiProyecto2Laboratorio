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


        public async Task<Recibo> GenerarReciboAsync(GenerarReciboDTO reciboDTO)
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
            reciboParaAgregar.Fecha = DateTime.Now;
            reciboParaAgregar.EstadoReciboId = 1;
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

                decimal? precioPrueba = await _pruebaLabRepositorio.Consultar().Where(x => x.PruebaDeLaboratorioId == item.IdPrueba)
                                                                          .Select(p => p.Precio)
                                                                          .FirstOrDefaultAsync();
                if (precioPrueba == null)
                    continue;

                pruebaDeLaboratorioRecibo.Add(new PruebaDeLaboratorioRecibo()
                {
                    PruebaDeLaboratorioId = item.IdPrueba,
                    ReciboId = reciboAgregado.ReciboId,
                    Precio = (decimal)precioPrueba
                });
            }


            reciboAgregado.PruebasDeLaboratorio.AddRange(pruebaDeLaboratorioRecibo);

            bool seEdito = await _reciboRepositorio.Editar(reciboAgregado);


            return reciboAgregado;

        }

        public async Task<Recibo?> BuscarReciboAsync(int idRecibo)
        {
            var recibo = await _reciboRepositorio.Obtener(r => r.ReciboId == idRecibo);

            return recibo;
        }

        //TODO: Implementar
        public Task<List<Recibo>> ListarRecibosAsync(int paginaActual, int? cantidadRegistros)
        {
            throw new System.NotImplementedException();
        }

        //TODO: Implementar
        public Task<bool> ReembolsarReciboAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
