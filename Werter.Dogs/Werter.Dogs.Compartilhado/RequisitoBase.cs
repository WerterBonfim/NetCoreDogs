using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Werter.Dogs.Compartilhado.Interfaces;

namespace Werter.Dogs.Compartilhado
{
    public abstract class RequisitoBase : IRequisitos
    {
        private IEnumerable<string> _errors;
        public abstract ValidationResult Validar();
        public bool EValido()
        {
            var result = Validar();

            _errors = result.Errors
                .Select(x => x.ErrorMessage)
                .ToList();
            
            return result.IsValid;
        }

        public IEnumerable<string> ListaErros()
        {
            return _errors;
        }

        public string ErroResumido => ListaErros().FirstOrDefault();
    }
}