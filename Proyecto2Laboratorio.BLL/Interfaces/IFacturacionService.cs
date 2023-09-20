using Proyecto2Laboratorio.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto2Laboratorio.BLL.Interfaces
{
    public interface IFacturacionService
    {
        //Quiero poner que en vez de devolver un object, retorne un DTO con el estado de las respuesta.
        Task<object> Facturar(Recibo factura);


    }
}
