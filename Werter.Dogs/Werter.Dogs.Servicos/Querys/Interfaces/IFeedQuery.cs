using System;
using System.Collections.Generic;
using Werter.Dogs.Dominio.Dtos;

namespace Werter.Dogs.Servicos.Querys.Interfaces
{
    public interface IFeedQuery : IQuery
    {
        public List<UsuarioDto> ListarFeed(int pagina = 1, int qtdPagina = 6);
        public UsuarioDto ListarFeedUsuario(Guid id,  int pagina = 1, int qtdPagina = 6);
    }
}