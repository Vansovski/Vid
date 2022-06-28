using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário o Nome do Cliente!")]
        [StringLength(255)]
        [Display(Name = "Nome do Cliente")]
        public string Nome { get; set; }

        [Display(Name = "Eviar Newsletter?")]
        public bool EnviarNewsLetter { get; set; }       

        public MembroTipo? MembroTipo { get; set; }

        [Required(ErrorMessage = "Coloque o tipo de assinatura para o Cliente")]
        [Display(Name = "Tipo de assinatura")]
        public byte? MembroTipoId { get; set; }

        public List<ClienteFilme>? Filmes { get; set; }

        [Display(Name = "Data de Aniversário")]
        [Menor18]
        public DateTime? DataAniversario { get; set; }
    }
}