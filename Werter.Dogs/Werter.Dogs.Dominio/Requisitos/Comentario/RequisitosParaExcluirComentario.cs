using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Validacoes.Comentario;

namespace Werter.Dogs.Dominio.Requisitos.Comentario
{
    public class RequisitosParaExcluirComentario : IRequisitos
    {
        private readonly ValidacaoParaExcluirComentario _validacao;
        private IEnumerable<string> _erros;

        public RequisitosParaExcluirComentario()
        {
            _validacao = new ValidacaoParaExcluirComentario();
            ;
        }

        public Guid Id { get; set; }

        public bool EValido()
        {
            var validacao = _validacao.Validate(this);
            _erros = validacao.Errors
                .Select(x => x.ErrorMessage)
                .ToArray();

            return validacao.IsValid;
        }

        public IEnumerable<string> ListaErros()
        {
            return _erros ??= new List<string>();
        }
    }
}