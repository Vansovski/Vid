using Vidly.Models;

namespace Vidly.ViewModel
{
    public class FilmeGeneros
    {
        public IEnumerable<Genero> Generos { get; set; }

        public Filme Filme { get; set; }
    }
}