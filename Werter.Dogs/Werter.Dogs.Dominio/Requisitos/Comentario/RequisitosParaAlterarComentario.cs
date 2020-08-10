using System;
using System.Collections.Generic;
using Werter.Dogs.Compartilhado.Interfaces;

namespace Werter.Dogs.Dominio.Requisitos.Comentario
{
    public class RequisitosParaAlterarComentario : IRequisitos
    {
        public Guid UsuarioId { get; set; }
        public Guid FotoId { get; set; }
        public string Texto { get; set; }
        public bool EValido()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ListaErros()
        {
            throw new NotImplementedException();
        }
    }
}