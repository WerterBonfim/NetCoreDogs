using System.Collections.Generic;

namespace Werter.Dogs.Compartilhado.Interfaces
{
    public interface IResultado
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
        public IEnumerable<string> Erros { get; set; }
    }
}