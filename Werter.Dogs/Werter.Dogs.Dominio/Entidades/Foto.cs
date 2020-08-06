using System;

namespace Werter.Dogs.Dominio.Entidades
{
    public class Foto : EntidadeBase
    {
        public string Nome { get; private set; }
        public int Peso { get; private set; }
        public int Idade { get; private set; }
        public string Src { get; set; }
        public int QuantidadeDeAcessos { get; set; }        
        public Usuario Usuario { get; set; }

        public Foto() { }
        public Foto(string nome, int peso, int idade)
        {
            this.Nome = nome;
            this.Peso = peso;
            this.Idade = idade;
        }       
    }
}
