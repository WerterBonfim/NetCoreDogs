using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Validacoes;

namespace Werter.Dogs.Dominio.Requisitos
{
    public sealed class RequisitosParaCriarUsuario : IRequisitos
    {
        private readonly ValidacaoParaCriarUsuario _validacoesDeUsuario;

        public RequisitosParaCriarUsuario()
        {
            _validacoesDeUsuario = new ValidacaoParaCriarUsuario();
        }

        public string NomeDeUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        private IEnumerable<string> _erros;

        public bool EValido()
        {
            var resultadoValidacao = _validacoesDeUsuario.Validate(this);

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
