using Vidly.Models;

namespace Vidly.App.Contratos
{
    public interface IClienteService
    {
        //Adiciona um novo Cliente
        Task<Cliente> AddCliente(Cliente model);

        //Obtém o cliente pelo Id
        Task<Cliente> getClienteById(int id,  bool includeMembroTipo = true);

        //Deleta o cliente pelo Id
        Task<bool> deleteCliente(int id);

    }
}