

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

        // Aqu� puedes llamar al repositorio de clientes para buscar un cliente por su ID.
        // La l�gica de implementaci�n real depender� de tu aplicaci�n.
        /*AQUIIII*/    
         Cliente? cliente =  await _clienteRepository.Obtener(d => d.ClienteId == idCliente);    
        if(cliente == null)
        {
            throw new Exepction("No se encontro el cliente");
        }

        return cliente;

����}
}