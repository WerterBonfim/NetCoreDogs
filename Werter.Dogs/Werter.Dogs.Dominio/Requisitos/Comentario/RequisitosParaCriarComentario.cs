using System;
using FluentValidation.Results;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Dominio.Validacoes.Comentario;

namespace Werter.Dogs.Dominio.Requisitos.Comentario
{
    public class RequisitosParaCriarComentario : RequisitoBase
    {
        public Guid FotoId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Texto { get; set; }

        public override ValidationResult Validar()
        {
            return new ValidacaoPararCriarComentario().Validate(this);
        }
    }
}