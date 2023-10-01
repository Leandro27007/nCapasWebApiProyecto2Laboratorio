using Proyecto2Laboratorio.Entities;
using System.Threading.Tasks;

public interface IClienteService
{

    Task<Cliente> CrearClienteAsync(Cliente cliente);
    Task<Cliente?> BuscarClientePorIdAsync(string? idCliente);
    Task<bool> EliminarClienteAsync(string? idCliente);
    Task<bool> EditarClienteAsync(Cliente cliente);

}



