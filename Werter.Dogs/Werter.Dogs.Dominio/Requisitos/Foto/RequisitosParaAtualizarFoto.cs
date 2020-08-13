using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Validacoes.Foto;

namespace Werter.Dogs.Dominio.Requisitos.Foto
{
    public class RequisitosParaAtualizarFoto : IRequisitos
    {
        private readonly ValidacaoParaAtualizarFoto _validacao;
        private IEnumerable<string> _erros;

        public RequisitosParaAtualizarFoto()
        {
            _validacao = new ValidacaoParaAtualizarFoto();
        }

        public Guid Id { get; set; }
        public int Idade { get; set; }
        public int Peso { get; set; }
        public string Nome { get; set; }


        public bool EValido()
        {
            var resultado = _validacao.Validate(this);
            _erros = resultado.Errors
                .Select(x => x.ErrorMessage)
                .ToArray();

            return resultado.IsValid;
        }

        public IEnumerable<string> ListaErros()
        {
            return _erros ??= new List<string>();
        }
    }
}