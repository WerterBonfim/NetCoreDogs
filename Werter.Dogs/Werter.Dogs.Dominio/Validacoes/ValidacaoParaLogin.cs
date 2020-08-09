using FluentValidation;
using Werter.Dogs.Dominio.Requisitos;

namespace Werter.Dogs.Dominio.Validacoes
{
    public class ValidacaoParaLogin : AbstractValidator<RequisitosParaLogin>
    {
        public ValidacaoParaLogin()
        {
            RuleFor(x => x.Login)
                .MinimumLength(3)
                .WithMessage("Login inválido");

            RuleFor(x => x.password)
                .MinimumLength(3)
                .WithMessage("Login inválido");
        }
    }
}