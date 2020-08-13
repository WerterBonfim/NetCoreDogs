using FluentValidation;
using Werter.Dogs.Dominio.Requisitos.Usuario;

namespace Werter.Dogs.Dominio.Validacoes.Usuario
{
    public class ValidacaoParaLogin : AbstractValidator<RequisitosParaLogin>
    {
        public ValidacaoParaLogin()
        {
            RuleFor(x => x.Login)
                .MinimumLength(3)
                .WithMessage("Login inválido");

            RuleFor(x => x.Senha)
                .MinimumLength(3)
                .WithMessage("Login inválido");
        }
    }
}