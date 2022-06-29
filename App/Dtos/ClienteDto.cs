using System.ComponentModel.DataAnnotations;

namespace Vidly.App.Dtos
{
    public class ClienteDto
    {
         public int Id { get; set; }

       
        public string Nome { get; set; }

     
        public bool EnviarNewsLetter { get; set; }       


        public byte? MembroTipoId { get; set; }

        public DateTime? DataAniversario { get; set; }
        
    }
}