using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Dominio.Dtos;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Servicos.Querys.Interfaces;

namespace Werter.Dogs.Servicos.Querys
{
    public class FeedQuery : IFeedQuery
    {
        private readonly IRepositorioCliente _repositorioCliente;

        public FeedQuery(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public List<UsuarioDto> ListarFeed(int pagina = 1, int qtdPagina = 6)
        {
            var testee = _repositorioCliente
                .Listar(pagina, qtdPagina, "Fotos")
                .ToList();
            
            // var usuarios = _repositorioCliente
            //     .Listar(pagina, qtdPagina, "Foto", "Comentarios")
            //     .OrderBy(x => x.DataHoraAlteracao)
            //     .ToList();
            
            return  new List<UsuarioDto>();
        }

        public UsuarioDto ListarFeedUsuario(Guid id, int pagina = 1, int qtdPagina = 6)
        {
            throw new NotImplementedException();
        }
    }
}