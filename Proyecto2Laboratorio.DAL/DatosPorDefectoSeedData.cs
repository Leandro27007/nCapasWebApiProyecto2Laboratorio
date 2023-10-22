using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Proyecto2Laboratorio.Entities;
using System;
using System.Linq;
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

                db.Database.EnsureCreated();

                if (!db.usuario.Any())
                {
                    db.Add(new Usuario()
                    {
                        UsuarioId = "40200000000",
                        Nombre = "Fabio",
                        Apellido = "Perez",
                        Email = "fp@gmail.com",
                        Username = "fabio123",
                        Password = "fabio123",
                        Telefono = "8090000000",
                        FechaRegistro = DateTime.Now
                    });

                    await db.SaveChangesAsync();
                }


                if (!db.pruebaDeLaboratorio.Any())
                {
                    db.Add(new PruebaDeLaboratorio()
                    {
                        Nombre = "Hemograma",
                        Descripcion = "Evaluar células sanguíneas: glóbulos rojos, leucocitos y plaquetas.",
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

    }
}
