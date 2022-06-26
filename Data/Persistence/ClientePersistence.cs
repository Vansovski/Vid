using Microsoft.EntityFrameworkCore;
using Vidly.Data.Persistence.Contratos;
using Vidly.Models;

namespace Vidly.Data.Persistence
{
    public class ClientePersistence : IClientePersistence
    {
        private readonly DataContext _context;
        public ClientePersistence(DataContext context)
        {
            _context = context;
        }
        public async Task<Cliente[]> getAllClientesAsync(int id, bool includeMembroTipo = true)
        {
            IQueryable<Cliente> query = _context.Clientes;

            if(includeMembroTipo)
            {
                query.Include(mt => mt.MembroTipo);
            }
            
            return await query.ToArrayAsync();               
        }

        public async Task<Cliente> getClienteByIdAsync(int id, bool includeMembroTipo = true)
        {
            IQueryable<Cliente> query = _context.Clientes;

            if(includeMembroTipo)
            {
                query.Include(mt => mt.MembroTipo);
            }

            query = query.Where(cliente => cliente.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}