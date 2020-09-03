using System;
using Werter.Dogs.Compartilhado.Interfaces;

namespace Werter.Dogs.Servicos.Querys.Interfaces
{
    public interface IFotoQuery : IQuery
    {
        public IResultado BuscarFoto(Guid fotoId, int qtdComentarios = 10);
    }
}