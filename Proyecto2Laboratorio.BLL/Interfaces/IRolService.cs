using DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Proyecto2Laboratorio.BLL.Interfaces
{
    public interface IRolService
    {
        Task<RolObtencionDTO> CrearRol(RolCreacionDTO rol);
        Task<bool> EditarRol(RolEdicionDTO rol);
        Task<List<RolObtencionDTO>> ListarRoles();
        Task<bool> Eliminar(int idRol);
    }
}
