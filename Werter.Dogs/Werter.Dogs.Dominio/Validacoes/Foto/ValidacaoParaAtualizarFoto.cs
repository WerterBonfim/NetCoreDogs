using System;
using FluentValidation;
using Werter.Dogs.Dominio.Requisitos.Foto;

namespace Werter.Dogs.Dominio.Validacoes.Foto
{
    public class ValidacaoParaAtualizarFoto : AbstractValidator<RequisitosParaAtualizarFoto>
    {
        public ValidacaoParaAtualizarFoto()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(2).WithMessage("O nome deve ter pelo menos 3 caracteres");
            
            
    
            RuleFor(x => x.Idade)
                .GreaterThan(0).WithMessage("Idade deve ser maior que 0")
                .LessThan(100).WithMessage("Idade inválida");

            RuleFor(x => x.Peso)
                .GreaterThan(0).WithMessage("Idade deve ser maior que 0");

            RuleFor(x => x.Id)
                .Custom((id, context) =>
                {
                    if (id == Guid.Empty)
                        context.AddFailure("Id inválido");
                });

        }
    }
}