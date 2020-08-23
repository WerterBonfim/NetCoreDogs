using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Validacoes.Usuario;

namespace Werter.Dogs.Dominio.Requisitos.Usuario
{
    public class RequisitosParaLogin : RequisitoBase
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public override ValidationResult Validar()
        {
            return new ValidacaoParaLogin().Validate(this);
        }
    }
}