using System;
using System.Collections.Generic;
using System.Text;

namespace Werter.Dogs.Compartilhado.Interfaces
{
    public interface IResultado
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
        public string[] Erros { get; set; }
    }
}
