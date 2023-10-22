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
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Recibo> recibo { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<PruebaDeLaboratorio> pruebaDeLaboratorio { get; set; }
        public DbSet<PruebaDeLaboratorioRecibo> pruebaDeLaboratorioRecibo { get; set; }
        public DbSet<Rol> rol { get; set; }
        public DbSet<Permiso> permiso { get; set; }
        public DbSet<Turno> turno { get; set; }
        public DbSet<TurnoPruebaDeLaboratorio> turnoPruebaDeLaboratorio { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

    }
}
