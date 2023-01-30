using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .MinimumLength(10)
                .WithMessage("O nome deve ter no mínimo 10 caracteres.")

                .MaximumLength(180)
                .WithMessage("O nome deve ter no máximo 180 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode ser vazia")

                .NotNull()
                .WithMessage("A senha não pode ser nula")
                
                .MinimumLength(8)
                .WithMessage("A senha deve ter no mínimo 8 caracteres.")

                .MaximumLength(32)
                .WithMessage("A senha deve ter no máximo 32 caracteres.")

                .Matches(@"^(?=.[a-z])(?=.[A-Z])(?=.\d)(?=.[@$!%?&])[A-Za-z\d@$!%?&]{8,}$")
                .WithMessage("A senha deve ter no mínimo 8 caracteres, letras maiúsculas e minusculas, caracteres especiais e números.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O e-mail não pode ser vazio.")

                .NotNull()
                .WithMessage("O e-mail não pode ser nulo.")

                .MinimumLength(3)
                .WithMessage("O e-mail deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O e-mail deve ter no máximo 80 caracteres.")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O e-mail deve estar em um formato válido.");
        }
    }
}