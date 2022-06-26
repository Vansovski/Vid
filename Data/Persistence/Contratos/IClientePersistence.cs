using Vidly.Models;

namespace Vidly.Data.Persistence.Contratos
{
    public interface IClientePersistence
    {
        Task<Cliente> getClienteByIdAsync(int id,  bool includeMembroTipo = true);
         Task<Cliente[]> getAllClientesAsync(int id, bool includeMembroTipo = true);
    }
}