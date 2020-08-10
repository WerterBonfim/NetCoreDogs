using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Validacoes.Foto;

namespace Werter.Dogs.Dominio.Requisitos.Foto
{
    public class RequisitosParaCadastrarFoto : IRequisitos
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Peso { get; set; }
        public Guid UsuarioId { get; set; }

        private readonly ValidacaoParaCadastrarUmaFoto _validacao;
        private IEnumerable<string> _erros;

        public RequisitosParaCadastrarFoto()
        {
            _validacao = new ValidacaoParaCadastrarUmaFoto();
        }

        public bool EValido()
        {
            var resultado = _validacao.Validate(this);
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