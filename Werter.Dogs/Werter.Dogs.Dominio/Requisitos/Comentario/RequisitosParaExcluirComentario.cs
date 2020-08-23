using System;
using FluentValidation.Results;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Dominio.Validacoes.Comentario;

namespace Werter.Dogs.Dominio.Requisitos.Comentario
{
    public class RequisitosParaExcluirComentario : RequisitoBase
    {
        public Guid Id { get; set; }
        public override ValidationResult Validar()
        {
            return new ValidacaoParaExcluirComentario().Validate(this);
        }
    }
}