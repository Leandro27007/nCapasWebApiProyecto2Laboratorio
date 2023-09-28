

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente> BuscarClientePorId(string? idCliente)
    {

        //LOGICA DE VALIDACION
        if(string.IsNullOrWhiteSpace(idCliente))
            idCliente == "0";

        // Aquí puedes llamar al repositorio de clientes para buscar un cliente por su ID.
        // La lógica de implementación real dependerá de tu aplicación.
        /*AQUIIII*/    
         Cliente? cliente =  await _clienteRepository.Obtener(d => d.ClienteId == idCliente);    
        if(cliente == null)
        {
            throw new Exepction("No se encontro el cliente");
        }

        return cliente;

    }
}