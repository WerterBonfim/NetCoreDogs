using FluentValidation;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Requisitos.Foto;

namespace Werter.Dogs.Dominio.Validacoes
{
    public class ValidacaoParaCadastrarUmaFoto : AbstractValidator<RequisitosParaCadastrarFoto>
    {
        public ValidacaoParaCadastrarUmaFoto()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(2).WithMessage("O nome deve ter pelo menos 3 caracteres");
    
            RuleFor(x => x.Idade)
                .LessThan(100).WithMessage("Idade inválida");               
                
        }
    }
}
