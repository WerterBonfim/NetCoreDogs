using System.Collections.Generic;
using Werter.Dogs.Compartilhado;

namespace Werter.Dogs.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        public Usuario()
        {
        }

        public Usuario(string nomeDeUsuario, string email, string senha) : this()
        {
            NomeDeUsuario = nomeDeUsuario;
            Email = email;
            Senha = senha;
        }

        public string Nome { get; private set; }
        public string NomeDeUsuario { get; }
        public string Email { get; }
        public string Senha { get; private set; }
        public virtual ICollection<Foto> Fotos { get; set; }

        public void AtualizarSenha(string senha)
        {
            var senhaCriptografada = HashUtil.GetSha256FromString(senha);
            Senha = senhaCriptografada;
            AtualizarDtHoraAlteracao();
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
            AtualizarDtHoraAlteracao();
        }
    }
}