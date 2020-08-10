using System;
using System.Collections;
using System.Collections.Generic;

namespace Werter.Dogs.Dominio.Entidades
{
    public class Foto : EntidadeBase
    {
        public string Nome { get; private set; }
        public int Peso { get; private set; }
        public int Idade { get; private set; }
        public int QuantidadeDeAcessos { get; private set; }
        public Usuario Usuario { get; private set; }
        public ICollection<Comentario> Comentarios { get; set; }
        public Guid UsuarioId { get; set; }

        public Foto()
        {
        }

        public Foto(string nome, int peso, int idade, Guid usuarioId)
        {
            this.Nome = nome;
            this.Peso = peso;
            this.Idade = idade;
            this.UsuarioId = usuarioId;
        }

        public void AtualizarIdade(int idade)
        {
            this.Idade = idade;
            this.AtualizarDtHoraAlteracao();
        }

        public void AtualizarPeso(int peso)
        {
            this.Peso = peso;
            this.AtualizarDtHoraAlteracao();
        }

        public void AtualizarNome(string nome)
        {
            this.Nome = nome;
            this.AtualizarDtHoraAlteracao();
        }

        public void IncrementarQtdAcessos()
        {
            this.QuantidadeDeAcessos += 1;
        }
    }
}