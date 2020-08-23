using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Validacoes.Usuario;

namespace Werter.Dogs.Dominio.Requisitos.Usuario
{
    public sealed class RequisitosParaAtualizarUsuario : RequisitoBase
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public override ValidationResult Validar()
        {
            return new ValidacaoParaAtualizarUsuario().Validate(this);
        }
    }
}