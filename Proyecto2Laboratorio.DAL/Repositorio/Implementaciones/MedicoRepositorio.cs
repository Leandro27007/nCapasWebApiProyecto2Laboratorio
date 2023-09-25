using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.DAL.Repositorio.Implementaciones
{
    public class MedicoRepositorio : RepositorioGenerico<Medico>, IMedicoRepositorio
    {
        //CREO UN COSNTRUCTOR Y LE PASO EL CONTEXTO DE LA BASE DE DATOS POR CONSTRUCTOR, YA QUE LO ESPERA.
        public MedicoRepositorio(ApplicationDbContext db) : base(db)
        {
        }



    }
}
