using Microsoft.EntityFrameworkCore;
using System.Linq;
using Vidly.Data.Persistence.Contratos;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Data.Persistence
{
    public class ClientePersistence : IClientePersistence
    {
        private readonly DataContext _context;
        public ClientePersistence(DataContext context)
        {
            _context = context;
        }
        public async Task<Cliente[]> getAllClientesAsync()
        {
            IQueryable<Cliente> query = _context.Clientes
                                                .Include(mt => mt.MembroTipo);

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

         public  ClienteFilmes getAllFilmesByClienteId(int id)
        {
            //Obtem o Cliente
            var cliente = getClienteByIdAsync(id).Result;

            var clienteFilmeList =  _context.ClientesFilmes
                                                .Include(f =>f.Filme)
                                                .Include(g =>g.Filme.Genero)
                                                .Where(cf => cf.ClienteId == id).ToList();


            List<Filme> filmes = new List<Filme>();
                
            foreach(var clienfilme in clienteFilmeList)
            {
                filmes.Add(clienfilme.Filme);
            }
            //Ciar ViewModel ClienteFilmes 
            var clienteFilmes = new ClienteFilmes{
                Cliente = cliente,
                Filmes = filmes
                };
            
            return clienteFilmes;               
        }

    }
}