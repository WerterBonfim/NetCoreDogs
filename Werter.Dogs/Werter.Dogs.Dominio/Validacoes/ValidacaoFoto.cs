using FluentValidation;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Dominio.Validacoes
{
    public class ValidacaoFoto : AbstractValidator<Foto>
    {
        public ValidacaoFoto()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(2).WithMessage("O nome deve ter pelo menos 3 caracteres");

            RuleFor(x => x.Idade)
                .LessThan(100).WithMessage("Idade inválida");               
                
        }
    }
}
