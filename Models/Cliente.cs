using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public bool EnviarNewsLetter { get; set; }
        
        public byte MembroTipoId { get; set; }        
        public MembroTipo MembroTipo { get; set; }
        public List<ClienteFilme>? Filmes { get; set; }
    }
}