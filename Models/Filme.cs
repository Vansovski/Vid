using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Titulo do Filme")]
        public string Titulo { get; set; }

        public List<ClienteFilme>? Clientes { get; set; }

        [Display(Name = "Data de Lançamento")]
        public DateTime DataLancamento { get; set; }

        public short GeneroId { get; set; }

        [Display(Name = "Genero do Filme")]
        [Required]
        public Genero Genero { get; set; }
    }
}