using Proyecto2Laboratorio.BLL.Interfaces;
using Proyecto2Laboratorio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Implementaciones
{
    public class ReciboService : IReciboService
    {

        //Se crea un atributo privado que almacenara el objeto de reciboRepositorio

        //private readonly IReciboRepositorio _reciboRepositorio;

        //Recibo un objeto de Recibo Repositorio desde la DAL
        public ReciboService(/*EJEMPLO:   IReciboRepositorio reciboRepositorio*/)
        {
            
            /*Se asigna el parametro al atributo:   reciboRepositorio = _reciboRepositorio*/

        }



        //SUGERENCIA RECIBIR DTO EN CONTROLADORES Y BLL
        public async Task<Recibo> GuardarReciboAsync(Recibo modelo)
        {
            //AQUI TODO TIPO DE VALIDACIONES

            if (modelo.ClienteId == null)
            {
                return modelo;
            }

            //Si el modelo recibido pasa la validacion LLamo al metodo de guardar de la DALL

            /*EJEMPLO:   reciboRepositorio.Crear(modelo)*/

            throw new System.NotImplementedException();
        }

        public Task<Recibo> BuscarReciboAsync(int idRecibo)
        {
            throw new System.NotImplementedException();
        }


        public Task<List<Recibo>> ListarRecibosAsync(int paginaActual, int? cantidadRegistros)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ReembolsarReciboAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
