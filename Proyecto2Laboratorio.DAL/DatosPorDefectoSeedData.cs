using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Proyecto2Laboratorio.Entities;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.DAL
{
    public class DatosPorDefectoSeedData
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScoped = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScoped.ServiceProvider.GetService<ApplicationDbContext>();

                if (db == null)
                    return;


                await db.Database.EnsureCreatedAsync();


                if (!db.rol.Any())
                {
                    db.Add(new Rol()
                    {
                        NombreRol = "Usuario",
                        Descripcion = "Rol por defecto",
                        FechaRegistro = DateTime.Now
                    });                    
                    db.Add(new Rol()
                    {
                        NombreRol = "Medico",
                        Descripcion = "Rol que permite despachar los pacientes",
                        FechaRegistro = DateTime.Now
                    });   
                    
                    db.Add(new Rol()
                    {
                        NombreRol = "Cajero",
                        Descripcion = "Rol que permite realizar procesos de facturacion",
                        FechaRegistro = DateTime.Now
                    });

                    db.Add(new Rol()
                    {
                        NombreRol = "Administrador",
                        Descripcion = "Rol por defecto",
                        FechaRegistro = DateTime.Now
                    });

                    await db.SaveChangesAsync();
                }


                if (!db.usuario.Any())
                {
                    db.Add(new Usuario()
                    {
                        UsuarioId = "40200000000",
                        Nombre = "Fabio",
                        Apellido = "Perez",
                        Email = "fp@gmail.com",
                        Username = "fabio123",
                        Password = HashPassword("fabio123"),
                        Telefono = "8090000000",
                        RolId = 4,
                        FechaRegistro = DateTime.Now
                    });

                    await db.SaveChangesAsync();
                }


                if (!db.pruebaDeLaboratorio.Any())
                {
                    db.Add(new PruebaDeLaboratorio()
                    {
                        Nombre = "Hemograma",
                        Descripcion = "Evaluar células sanguíneas.",
                        Precio = 750.50m,
                        Fecha = DateTime.Now,
                        Recibos = null!,
                        turnoPruebaDeLaboratorios = null!
                    });                    
                    db.Add(new PruebaDeLaboratorio()
                    {
                        Nombre = "Orina",
                        Descripcion = "Evaluar la orina.",
                        Precio = 950.50m,
                        Fecha = DateTime.Now,
                        Recibos = null!,
                        turnoPruebaDeLaboratorios = null!
                    });                    
                    db.Add(new PruebaDeLaboratorio()
                    {
                        Nombre = "Glicemia",
                        Descripcion = "Examen de Glicemia",
                        Precio = 650.99m,
                        Fecha = DateTime.Now,
                        Recibos = null!,
                        turnoPruebaDeLaboratorios = null!
                    });                 
                    db.Add(new PruebaDeLaboratorio()
                    {
                        Nombre = "Colesterol HDL",
                        Descripcion = "Se mide el colesteror HDL.",
                        Precio = 700.50m,
                        Fecha = DateTime.Now,
                        Recibos = null!,
                        turnoPruebaDeLaboratorios = null!
                    });                    
                    db.Add(new PruebaDeLaboratorio()
                    {
                        Nombre = "Perfil Lipídico",
                        Descripcion = "Se miden el colesterol total",
                        Precio = 1500.00m,
                        Fecha = DateTime.Now,
                        Recibos = null!,
                        turnoPruebaDeLaboratorios = null!
                    });                
                    db.Add(new PruebaDeLaboratorio()
                    {
                        Nombre = "Prueba de Embarazo",
                        Descripcion = "Se realiza prueba de embarazo.",
                        Precio = 700.00m,
                        Fecha = DateTime.Now,
                        Recibos = null!,
                        turnoPruebaDeLaboratorios = null!
                    });

                    await db.SaveChangesAsync();
                }



            }


        }
        private static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var randomGenerator = RandomNumberGenerator.Create())
            {
                randomGenerator.GetBytes(salt);
            }
            var rfcPassword = new Rfc2898DeriveBytes(password, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassword.GetBytes(20);

            byte[] passwordHash = new byte[36];
            Array.Copy(salt, 0, passwordHash, 0, 16);
            Array.Copy(rfcPasswordHash, 0, passwordHash, 16, 20);
            return Convert.ToBase64String(passwordHash);
        }
    }
}
