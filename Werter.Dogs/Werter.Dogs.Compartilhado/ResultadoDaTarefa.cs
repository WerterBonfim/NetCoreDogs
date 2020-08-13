using System.Collections.Generic;
using Werter.Dogs.Compartilhado.Interfaces;

namespace Werter.Dogs.Compartilhado
{
    public sealed class ResultadoDaTarefa : IResultado
    {
        public ResultadoDaTarefa()
        {
        }

        public ResultadoDaTarefa(bool sucesso, string mensagem, object dados = null,
            IEnumerable<string> listaDeErros = null)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
            Erros = listaDeErros;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
        public IEnumerable<string> Erros { get; set; }
    }
}