using FluentValidation;
using System;
using Werter.Dogs.Dominio.Requisitos;

namespace Werter.Dogs.Dominio.Validacoes
{
    public sealed class ValidacaoParaAtualizarUsuario : AbstractValidator<RequisitosParaAtualizarUsuario>
    {
        public ValidacaoParaAtualizarUsuario()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id não pode ser nullo")
                .Custom((id, context) =>
                {
                    if (id == Guid.Empty)
                        context.AddFailure("Id inválido");
                }); 

            RuleFor(x => x.Nome)
                .Custom((nome, context) =>
                {
                    if (!string.IsNullOrEmpty(nome) && nome.Length < 3)
                        context.AddFailure("Nome", "O nome deve conter pelo menos 3 caracteres");                        
                });

            RuleFor(x => x.Senha)
                .Custom((senha, context) =>
                {
                    if (!string.IsNullOrEmpty(senha) && senha.Length < 3)
                        context.AddFailure("Nome", "Senha deve conter pelo menos 3 caracteres");
                });
        }
    }
}
