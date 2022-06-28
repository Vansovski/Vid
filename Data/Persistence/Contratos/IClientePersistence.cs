using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Data.Persistence.Contratos
{
    public interface IClientePersistence
    {
        Task<Cliente> getClienteByIdAsync(int id,  bool includeMembroTipo = true);
        Task<Cliente[]> getAllClientesAsync();
        ClienteFilmes getAllFilmesByClienteId(int id);
    }
}