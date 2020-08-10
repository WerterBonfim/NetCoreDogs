using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Validacoes;

namespace Werter.Dogs.Dominio.Requisitos
{
    public class RequisitosParaLogin : IRequisitos
    {
        private readonly ValidacaoParaLogin _validacaoParaLogin;
        private IEnumerable<string> _erros;

        public RequisitosParaLogin()
        {
            _validacaoParaLogin = new ValidacaoParaLogin();
        }
        
        public string Login { get; set; }
        public string password { get; set; }
        
        public bool EValido()
        {
            var resultadoValidacao = _validacaoParaLogin.Validate(this);
            _erros = Enumerable.Select(resultadoValidacao
                .Errors, x => x.ErrorMessage);

            return resultadoValidacao.IsValid;
        }

        public IEnumerable<string> ListaErros()
        {
            return _erros;
        }
    }
}