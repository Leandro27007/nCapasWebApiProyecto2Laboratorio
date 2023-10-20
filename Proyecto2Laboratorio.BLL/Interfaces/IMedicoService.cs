using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto2Laboratorio.BLL.Interfaces
{
    public interface IMedicoService
    {
        Task<List<PacienteDTO>?> ListarPacientesEnEspera();
        Task<PacienteDTO?> BuscarPaciente(int IdRecibo);
        Task<bool> CambiarEstadoDeRecibo(int idRecibo, string nuevoEstado);
        Task<List<string>?> ObtenerEstadosDeRecibo();
    }
}
