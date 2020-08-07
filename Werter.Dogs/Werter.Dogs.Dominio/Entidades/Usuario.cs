using System;
using System.Collections.Generic;

namespace Werter.Dogs.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; private set; }
        public string NomeDeUsuario { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public ICollection<Foto> Fotos { get; set; }



        public Usuario() { }
        public Usuario(string nomeDeUsuario, string email, string senha) : this()
        {
            this.NomeDeUsuario = nomeDeUsuario;
            this.Email = email;
            this.Senha = senha;            
        }

        public void AtualizarSenha(string senha)
        {
            this.Senha = senha;
            this.DataHoraAlteracao = DateTime.Now;
        }

        public void AtualizarNome(string nome)
        {
            this.Nome = nome;
            this.DataHoraAlteracao = DateTime.Now;
        }
    }
}
