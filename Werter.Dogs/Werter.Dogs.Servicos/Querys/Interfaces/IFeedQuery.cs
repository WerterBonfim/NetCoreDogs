using System;
using System.Collections.Generic;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Dtos;

namespace Werter.Dogs.Servicos.Querys.Interfaces
{
    public interface IFeedQuery : IQuery
    {
        public IResultado ListarFeed(int pagina = 1, int qtdUsuario = 3, int qtdFotos = 6);
        public IResultado ListarFeedUsuario(Guid id,  int pagina = 1, int qtdPorPagina = 6);
        public IResultado ListarFeedUsuario(string nomeDeUsuario,  int pagina = 1, int qtdPorPagina = 6);
    }
}