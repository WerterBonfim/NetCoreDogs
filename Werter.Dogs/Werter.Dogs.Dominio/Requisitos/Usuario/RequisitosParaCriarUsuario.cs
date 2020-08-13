using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Validacoes.Usuario;

namespace Werter.Dogs.Dominio.Requisitos.Usuario
{
    public sealed class RequisitosParaCriarUsuario : IRequisitos
    {
        private readonly ValidacaoParaCriarUsuario _validacoesDeUsuario;

        private IEnumerable<string> _erros;

        public RequisitosParaCriarUsuario()
        {
            _validacoesDeUsuario = new ValidacaoParaCriarUsuario();
        }

        public string NomeDeUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

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