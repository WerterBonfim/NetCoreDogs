using System;
using System.Collections.Generic;
using System.Text;

namespace Werter.Dogs.Compartilhado.Interfaces
{
    public interface IRequisitos
    {
        bool EValido();
        IEnumerable<string> ListaErros();
    }
}
