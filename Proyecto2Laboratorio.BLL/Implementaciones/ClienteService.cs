using Proyecto2Laboratorio.DAL.Repositorio.Interfaces;
using Proyecto2Laboratorio.Entities;
using System;
using System.IO;
using System.Threading.Tasks;

public class ClienteService : IClienteService
{
    private readonly IClienteRepositorio _clienteRepository;

    public ClienteService(IClienteRepositorio clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }



    public async Task<Cliente?> BuscarClientePorIdAsync(int? idCliente)
    {
        //Esto puede ser no necesario si valido con la propiedad ModelState en el controller.
        //LOGICA DE VALIDACION: Si el idCliente es de una longitud no permitida o si viene null o blank lanzo una exepcion
        if (idCliente == null || idCliente <= 0)
            throw new IOException("Error en la entrada de datos. Id no valido.");

        //Pido el cliente a mi repositorio de datos de manera asincrona.
        Cliente? cliente = await _clienteRepository.Obtener(d => d.ClienteId == idCliente);

        return cliente;
    }

    public async Task<bool> EditarClienteAsync(Cliente cliente)
    {
        bool seEdito;
        try
        {
            //Mando a editar al cliente
            seEdito = await _clienteRepository.Editar(cliente);
        }
        //Actualmente dejo que se detecten exepciones generales producidas en acceso a datos, ya luego refactorizo para detectar exepciones especificas.
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return seEdito;
    }



    public async Task<bool> EliminarClienteAsync(int? idCliente)
    {
        //Esto puede ser no necesario si valido con la propiedad ModelState en el controller.
        //LOGICA DE VALIDACION: Si el idCliente es de una longitud no permitida o si viene null o blank lanzo una exepcion
        if (idCliente == null || idCliente <= 0)
            throw new IOException("Error en la entrada de datos. Id no valido.");

        bool seElimino = false;
        try
        {
            //Obtengo el cliente que quier eliminar.
            Cliente? cliente = await _clienteRepository.Obtener(d => d.ClienteId == idCliente);

            //Mando a eliminar el cliente
            if(cliente != null)
            seElimino = await _clienteRepository.Eliminar(cliente);

        }
        //Actualmente dejo que se detecten exepciones generales producidas en acceso a datos, ya luego refactorizo para detectar exepciones especificas.
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return seElimino;
    }
}