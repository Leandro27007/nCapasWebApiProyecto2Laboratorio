using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto2Laboratorio.Entities;

namespace Proyecto2Laboratorio.DAL
{
    public class ApplicationDbContext  : DbContext
    {

        public ApplicationDbContext(DbContextOptions opciones) : base(opciones)
        {

        }

        DbSet<Cliente> Cliente { get; set; }
        DbSet<Recibo> Recibo { get; set; }
        DbSet<Medico> Medico { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        DbSet<EstadoRecibo> estadoRecibo { get; set; }
        DbSet<PruebaDeLaboratorio> pruebaDeLaboratorios { get; set; }
        DbSet<Roles> Roles { get; set; }



    }
}
