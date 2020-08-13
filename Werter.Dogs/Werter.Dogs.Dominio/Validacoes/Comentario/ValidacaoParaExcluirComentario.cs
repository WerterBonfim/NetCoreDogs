using FluentValidation;
using Werter.Dogs.Compartilhado.Validacao;
using Werter.Dogs.Dominio.Requisitos.Comentario;

namespace Werter.Dogs.Dominio.Validacoes.Comentario
{
    public class ValidacaoParaExcluirComentario : AbstractValidator<RequisitosParaExcluirComentario>
    {
        public ValidacaoParaExcluirComentario()
        {
            RuleFor(x => x.Id)
                .SetValidator(new ValidacaoDeId());
        }
    }
}