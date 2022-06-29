using Vidly.App.Dtos;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.App.Contratos
{
    public interface IClienteService
    {
        //Adiciona um novo Cliente
        Task<ClienteDto> AddCliente(ClienteDto model);

        //Obtém o cliente pelo Id
        Task<ClienteDto> getClienteById(int id,  bool includeMembroTipo = true);

        //Obtem todos os Cliente
        Task<ClienteDto[]> getAllClientesAsync(bool includeMembroTipo = true);

        Task<bool> updateClienteAsync(ClienteDto cliente);

        //Obtem o cliente e os seus filmes 
        ClienteFilmes getClienteFilmes(int id);

        //Deleta o cliente pelo Id
        Task<bool> deleteCliente(int id);
    }

}