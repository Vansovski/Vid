using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genero
    {
        public short Id { get; set; }

        [Required(ErrorMessage ="Nome do Genero é necessário")]
        [Display(Name = "Genero")]
        public string Nome { get; set; }
    }
}