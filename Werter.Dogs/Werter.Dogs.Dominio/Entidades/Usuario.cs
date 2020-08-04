using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Dominio.Interfaces;
using Werter.Dogs.Dominio.Validacoes;

namespace Werter.Dogs.Dominio.Entidades
{
    public class Usuario : EntidadeBase, IValidacao
    {
        public string Nome { get; set; }
        public string NomeDeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }        
        private readonly ValidacaoUsuario _validacoes;
        

        public Usuario()
        {
            _validacoes = new ValidacaoUsuario();
        }
        public Usuario(string nomeDeUsuario, string email, string senha) : this()
        {
            this.NomeDeUsuario = nomeDeUsuario;
            this.Email = email;
            this.Senha = senha;
        }

        public void AtualizarSenha(string senha)
        {
            this.Senha = senha;
        }

        public bool EValido()
        {
            return _validacoes.Validate(this).IsValid;
        }

        public IList<DetalheErro> ListaErrors()
        {
            return _validacoes.Validate(this)
                .Errors
                .Select(x => new DetalheErro(x.PropertyName, x.ErrorMessage))
                .ToList();
        }
    }
}
