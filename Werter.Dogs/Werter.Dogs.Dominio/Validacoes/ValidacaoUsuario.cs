using FluentValidation;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Dominio.Validacoes
{
    public class ValidacaoUsuario : AbstractValidator<Usuario>
    {
        public ValidacaoUsuario()
        {
            RuleFor(x => x.NomeDeUsuario)
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(15)
                .WithMessage("Nome de usuario inválido, deve ter entre 4 a 15 caracteres");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(x => x.Senha)
                .MinimumLength(4)
                .MaximumLength(10);
        }

        

    }
}
