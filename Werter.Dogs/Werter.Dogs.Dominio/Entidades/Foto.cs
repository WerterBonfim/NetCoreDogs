using System;
using System.Collections.Generic;

namespace Werter.Dogs.Dominio.Entidades
{
    public class Foto : EntidadeBase
    {
        public Foto()
        {
        }

        public Foto(string nome, int peso, int idade, Guid usuarioId, string extencao)
        {
            Nome = nome;
            Peso = peso;
            Idade = idade;
            UsuarioId = usuarioId;
            Extencao = extencao;
        }

        public string Nome { get; private set; }
        public int Peso { get; private set; }
        public int Idade { get; private set; }
        public int QuantidadeDeAcessos { get; private set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public Guid UsuarioId { get; set; }
        public string Extencao { get; private set; }

        public void AtualizarIdade(int idade)
        {
            Idade = idade;
            AtualizarDtHoraAlteracao();
        }

        public void AtualizarPeso(int peso)
        {
            Peso = peso;
            AtualizarDtHoraAlteracao();
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
            AtualizarDtHoraAlteracao();
        }

        public void IncrementarQtdAcessos()
        {
            QuantidadeDeAcessos += 1;
        }
    }
}