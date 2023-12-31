using Proyecto2Laboratorio.Entities;
using System.Threading.Tasks;

public interface IClienteService
{

    Task<Cliente?> BuscarClientePorIdAsync(int? idCliente);
    Task<bool> EliminarClienteAsync(int? idCliente);
    Task<bool> EditarClienteAsync(Cliente cliente);

}



