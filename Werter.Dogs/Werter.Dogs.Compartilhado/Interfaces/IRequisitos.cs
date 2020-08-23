using System.Collections.Generic;

namespace Werter.Dogs.Compartilhado.Interfaces
{
    public interface IRequisitos
    {
        bool EValido();
        IEnumerable<string> ListaErros();
        string ErroResumido { get; }
    }
}