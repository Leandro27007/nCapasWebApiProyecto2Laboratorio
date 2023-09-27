﻿using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using Proyecto2Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.DAL.Repositorio.Implementaciones
{
    public class PruebaDeLaboratorioRepositorio : RepositorioGenerico<PruebaDeLaboratorio>, IPruebaDeLaboratorioRepositorio
    {
        public PruebaDeLaboratorioRepositorio(ApplicationDbContext db) : base(db) 
        {
        }
    }
}
