using System.Collections.Generic;
using Werter.Dogs.Dominio.Validacoes;

namespace Werter.Dogs.Dominio.Interfaces
{
    public interface IValidacao
    {
        bool EValido();
        IList<DetalheErro> ListaErrors();
    }
}