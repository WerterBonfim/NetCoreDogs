using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Compartilhado.Validacao;

namespace Werter.Dogs.Dominio.Requisitos.Foto
{
    public class RequisitosParaExcluirFoto : IRequisitos
    {
        public Guid Id { get; set; }

        private readonly ValidacaoDeId _validacao;
        private IEnumerable<string> _erros;

        public RequisitosParaExcluirFoto()
        {
            _validacao = new ValidacaoDeId();
        }
        
        public RequisitosParaExcluirFoto(Guid id) : this()
        {
            this.Id = id;
        }

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