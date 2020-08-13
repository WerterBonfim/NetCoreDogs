using FluentValidation;
using Werter.Dogs.Compartilhado.Validacao;
using Werter.Dogs.Dominio.Requisitos.Comentario;

namespace Werter.Dogs.Dominio.Validacoes.Comentario
{
    public class ValidacaoPararCriarComentario : AbstractValidator<RequisitosParaCriarComentario>
    {
        public ValidacaoPararCriarComentario()
        {
            RuleFor(x => x.FotoId)
                .SetValidator(new ValidacaoDeId());

            RuleFor(x => x.UsuarioId)
                .SetValidator(new ValidacaoDeId());

            RuleFor(x => x.Texto)
                .MinimumLength(1).WithMessage("Comentário deve ter mais de um carácter");
        }
    }
}