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

        DbSet<Cliente> cliente { get; set; }
        DbSet<Recibo> recibo { get; set; }
        DbSet<Usuario> usuario { get; set; }
        DbSet<EstadoRecibo> estadoRecibo { get; set; }
        DbSet<PruebaDeLaboratorio> pruebaDeLaboratorio { get; set; }
        DbSet<PruebaDeLaboratorioRecibo> pruebaDeLaboratorioRecibo { get; set; }
        DbSet<UsuarioRecibo> usuarioRecibo { get; set; }
        DbSet<Rol> rol { get; set; }
        DbSet<Permiso> permiso { get; set; }
        DbSet<Turno> turno { get; set; }
        DbSet<EstadoTurno> estadoTurno { get; set; }
        DbSet<TurnoPruebaDeLaboratorio> turnoPruebaDeLaboratorio { get; set; }


    }
}
