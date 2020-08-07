using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Validacoes;

namespace Werter.Dogs.Dominio.Requisitos
{
    public sealed class RequisitosParaAtualizarUsuario : IRequisitos
    {
        private readonly ValidacaoParaAtualizarUsuario _validacoes;
        private IEnumerable<string> _erros;

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public RequisitosParaAtualizarUsuario()
        {
            _validacoes = new ValidacaoParaAtualizarUsuario();
        }


        public bool EValido()
        {
            var resultadoValidacao = _validacoes.Validate(this);

            _erros = resultadoValidacao
                .Errors
                .Select(x => x.ErrorMessage);

            return resultadoValidacao.IsValid;
        }

        public IEnumerable<string> ListaErros()
        {
            return _erros;
        }
    }
}
