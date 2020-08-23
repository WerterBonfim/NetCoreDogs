using System;
using FluentValidation.Results;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Dominio.Validacoes.Foto;

namespace Werter.Dogs.Dominio.Requisitos.Foto
{
    public class RequisitosParaAtualizarFoto : RequisitoBase
    {
        public Guid Id { get; set; }
        public int Idade { get; set; }
        public int Peso { get; set; }
        public string Nome { get; set; }

        public override ValidationResult Validar()
        {
            return new ValidacaoParaAtualizarFoto().Validate(this);
        }
    }
}