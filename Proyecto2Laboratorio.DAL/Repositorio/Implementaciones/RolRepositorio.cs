using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.DAL.Repositorio.Implementaciones
{
    public class RolRepositorio : RepositorioGenerico<Rol>, IRolRepositorio
    {


        //CREO UN COSNTRUCTOR Y LE PASO EL CONTEXTO DE LA BASE DE DATOS POR CONSTRUCTOR, YA QUE LO ESPERA.
        public RolRepositorio(ApplicationDbContext db) : base(db)
        {
        }


        //AQUI YA NO VA NADA


    }
}
