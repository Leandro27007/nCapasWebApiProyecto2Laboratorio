using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Implementaciones
{
    public class ReciboService : IReciboService
    {


        private readonly IReciboRepositorio _reciboRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;

        public ReciboService(IReciboRepositorio reciboRepositorio, IClienteRepositorio clienteRepositorio)
        {
            this._reciboRepositorio = reciboRepositorio;
            this._clienteRepositorio = clienteRepositorio;
        }


        public async Task<Recibo> GuardarReciboAsync(Recibo modelo)
        {
            return await _reciboRepositorio.Crear(modelo);
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
