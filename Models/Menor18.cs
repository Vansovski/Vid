using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Menor18 : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var cliente = (Cliente)validationContext.ObjectInstance;

            if (cliente.MembroTipoId == 1 )
            {
               return ValidationResult.Success;
            }

            if(cliente.DataAniversario == null){
                return new ValidationResult("Data de aniversário é Obrigatório!");
            }
            
            var age = DateTime.Today.Year - cliente.DataAniversario.Value.Year;

            return (age>= 18) ? ValidationResult.Success : new ValidationResult("Cliente deve ser maior de 18 anos!");
        
        }
    }
}