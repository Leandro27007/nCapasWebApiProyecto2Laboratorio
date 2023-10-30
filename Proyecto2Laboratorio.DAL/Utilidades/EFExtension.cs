using Microsoft.EntityFrameworkCore;
using Proyecto2Laboratorio.Entities;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.DAL.Utilidades
{
    public static class EFExtension
    {
        public static async Task<string> ObtenerSiguienteId(this DbSet<Turno> dbSet)
        {

            string? ultimoId = await dbSet.OrderByDescending(t => t.FechaRegistro).Select(t => t.TurnoId).FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(ultimoId))
            {
                return "T-1";
            }

            int numeroTurno = ExtraerNumeroDeIdTurno(ultimoId);

            numeroTurno++;


            string siguienteId = $"T-{numeroTurno}";

            return siguienteId;
        }

        private static int ExtraerNumeroDeIdTurno(string idTurno = "T-0")
        {
            string numeroDeIdTurno = Regex.Replace(idTurno, "T-", "").Trim();
            int numeroTurno = 0;
            int.TryParse(numeroDeIdTurno, out numeroTurno);

            return numeroTurno;
        }


    }
}
