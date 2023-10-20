using System.Collections.Generic;

namespace Proyecto2Laboratorio.BLL.Utilidades
{
    public static class EstadosRecibo
    {
        public const string PENDIENTE = "Pendiente";
        public const string ESPERA_RESULTADOS = "EnEsperaResultados";
        public const string COMPLETADO = "Completado";
        public const string REEMBOLSADO = "Reembolsado";


        public static readonly List<string> estados = new List<string>() 
        {  
            PENDIENTE,
            ESPERA_RESULTADOS,
            COMPLETADO,
            REEMBOLSADO
        };
    }
}
