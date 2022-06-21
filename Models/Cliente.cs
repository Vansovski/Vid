using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nome do Cliente")]
        public string Nome { get; set; }

        [Display(Name = "Eviar Newsletter?")]
        public bool EnviarNewsLetter { get; set; }

        [Display(Name = "Tipo de Membro")]
        public byte MembroTipoId { get; set; }       

        public MembroTipo MembroTipo { get; set; }

        public List<ClienteFilme>? Filmes { get; set; }

        [Display(Name = "Data de Aniversário")]
        public DateTime? DataAniversario { get; set; }
    }
}