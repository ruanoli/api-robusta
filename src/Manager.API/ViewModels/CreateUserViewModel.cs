using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "A entidade não pode ser nula.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 03 caracteres.")]
        [MaxLength(180, ErrorMessage = "O nome deve ter no mínimo 180 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O e-mail não pode ser vazio.")]
        [MinLength(3, ErrorMessage = "O e-mail deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O e-mail deve ter no máximo 80 caracteres.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        , ErrorMessage = "O e-mail deve estar em um formato válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazia")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        [MaxLength(80, ErrorMessage = "A senha deve ter no máximo 32 caracteres.")]
        public string Password { get; set; } 
    }
}