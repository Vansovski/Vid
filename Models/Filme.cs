using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Titulo do Filme")]
        public string Titlo { get; set; }

        public List<ClienteFilme>? Clientes { get; set; }

        [Display(Name = "Data de Lancamento")]
        public DateTime DataLancamento { get; set; }

        public short GeneroId { get; set; }

        [Display(Name = "Genero do Filme")]
        public Genero Genero { get; set; }

        public int Qtd { get; set; }
        
    }
}