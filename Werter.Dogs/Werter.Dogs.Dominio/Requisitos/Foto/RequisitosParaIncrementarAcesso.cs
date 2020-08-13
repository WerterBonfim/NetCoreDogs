using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Compartilhado.Validacao;

namespace Werter.Dogs.Dominio.Requisitos.Foto
{
    public class RequisitosParaIncrementarAcesso : IRequisitos
    {
        private readonly ValidacaoDeId _validacao;
        private IEnumerable<string> _erros;

        public RequisitosParaIncrementarAcesso()
        {
            _validacao = new ValidacaoDeId();
        }

        public Guid Id { get; set; }

        public bool EValido()
        {
            var resultado = _validacao.Validate(Id);
            _erros = resultado.Errors
                .Select(x => x.ErrorMessage)
                .ToList();

            return resultado.IsValid;
        }

        public IEnumerable<string> ListaErros()
        {
            return _erros ??= new List<string>();
        }
    }
}