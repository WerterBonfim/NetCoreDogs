using System.Collections.Generic;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Validacoes;

namespace Werter.Dogs.Dominio.Requisitos
{
    public class RequisitosParaLogin : IRequisitos
    {
        public RequisitosParaLogin()
        {
            new ValidacaoParaLogin();
        }
        
        public string Login { get; set; }
        public string password { get; set; }
        
        public bool EValido()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> ListaErros()
        {
            throw new System.NotImplementedException();
        }
    }
}