using System;
using FluentValidation.Results;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Validacao;

namespace Werter.Dogs.Dominio.Requisitos.Foto
{
    public class RequisitosParaIncrementarAcesso : RequisitoBase
    {
        public Guid Id { get; set; }


        public override ValidationResult Validar()
        {
            return new ValidacaoDeId().Validate(this.Id);
        }
    }
}