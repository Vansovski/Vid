using Vidly.Models;

namespace Vidly.ViewModel
{
    public class ClienteFilmes
    {
        public Cliente Cliente { get; set; }
        
        public IEnumerable<Filme> Filmes { get; set; }
        
    }
}