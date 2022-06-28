using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.App.Contratos
{
    public interface IClienteService
    {
        //Adiciona um novo Cliente
        Task<Cliente> AddCliente(Cliente model);

        //Obtém o cliente pelo Id
        Task<Cliente> getClienteById(int id,  bool includeMembroTipo = true);

        //Obtem todos os Cliente
        Task<Cliente[]> getAllClientesAsync();

        Task<bool> updateClienteAsync(Cliente cliente);

        //Obtem o cliente e os seus filmes 
        ClienteFilmes getClienteFilmes(int id);

        //Deleta o cliente pelo Id
        Task<bool> deleteCliente(int id);
    }

}