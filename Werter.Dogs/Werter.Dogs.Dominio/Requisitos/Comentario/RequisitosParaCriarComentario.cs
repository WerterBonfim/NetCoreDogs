using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Validacoes.Comentario;

namespace Werter.Dogs.Dominio.Requisitos.Comentario
{
    public class RequisitosParaCriarComentario : IRequisitos
    {
        private readonly ValidacaoPararCriarComentario _validacao;
        private IEnumerable<string> _erros;

        public RequisitosParaCriarComentario()
        {
            _validacao = new ValidacaoPararCriarComentario();
            ;
        }

        public Guid FotoId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Texto { get; set; }

        public bool EValido()
        {
            var validacao = _validacao.Validate(this);
            _erros = validacao.Errors
                .Select(x => x.ErrorMessage)
                .ToArray();

            return validacao.IsValid;
        }

        public IEnumerable<string> ListaErros()
        {
            return _erros ??= new List<string>();
        }
    }
}