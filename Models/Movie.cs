using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ClienteFilme>? Clientes { get; set; }

        public static List<Movie> listarFilmes()
        {
             var filmes = new List<Movie>
            {
                new Movie { Id = 1, Name = "Pequeno Principe"},
                new Movie { Id = 2, Name = "Abril despedaçado"},
                new Movie { Id = 3, Name = "As Panteras"},
                new Movie { Id = 4, Name = "Rei Leão"},
                new Movie { Id = 5, Name = "O ditador"},
            };

            return filmes;
        }
    }
}