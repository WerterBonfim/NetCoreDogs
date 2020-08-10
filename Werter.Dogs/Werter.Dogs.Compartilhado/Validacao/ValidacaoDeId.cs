using System;
using FluentValidation;

namespace Werter.Dogs.Compartilhado.Validacao
{
    public class ValidacaoDeId : AbstractValidator<Guid>
    {
        public ValidacaoDeId()
        {
            RuleFor(x => x)
                .Custom(((guid, context) =>
                {
                    if (guid == Guid.Empty)
                        context.AddFailure("Id inválido");
                }));

        }
    }
}