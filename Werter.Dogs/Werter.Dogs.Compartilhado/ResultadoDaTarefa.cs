using Werter.Dogs.Compartilhado.Interfaces;

namespace Werter.Dogs.Compartilhado
{
    public sealed class ResultadoDaTarefa : IResultado
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
        public string[] Erros { get; set; }

        public ResultadoDaTarefa() { }
        public ResultadoDaTarefa(bool sucesso, string mensagem, object dados = null, string[] listaDeErros = null)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
            this.Dados = dados;
            this.Erros = listaDeErros;
        }
    }
}
