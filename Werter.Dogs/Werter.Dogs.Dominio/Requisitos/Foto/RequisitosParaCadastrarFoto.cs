using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Validacoes.Foto;

namespace Werter.Dogs.Dominio.Requisitos.Foto
{
    public class RequisitosParaCadastrarFoto : RequisitoBase
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Peso { get; set; }
        public Guid UsuarioId { get; set; }
        public string Extencao { get; set; }

        public override ValidationResult Validar()
        {
            return new ValidacaoParaCadastrarUmaFoto().Validate(this);
        }
    }
}