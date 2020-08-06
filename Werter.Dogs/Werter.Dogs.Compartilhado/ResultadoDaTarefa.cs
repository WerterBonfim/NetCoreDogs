using Werter.Dogs.Compartilhado.Interfaces;

namespace Werter.Dogs.Compartilhado
{
    public sealed class ResultadoDaTarefa : IResultado
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

        public string[] Erros { get; set; }

        public ResultadoDaTarefa() { }
        public ResultadoDaTarefa(bool sucesso, string mensagem, string[] listaDeErros = null)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
            this.Erros = listaDeErros;
        }
    }
}
