using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Conversoes;
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

        public IResultado ListarFeed(int pagina = 1, int qtdUsuario = 3, int qtdFotos = 6)
        {
            try
            {
                var usuario = _repositorioCliente
                    .Queryable()
                    .Include(x => x.Fotos)
                    .Select(x => x.ParaDto(qtdFotos))
                    .ToList();

                return new ResultadoDaTarefa(
                    true,
                    "Consulta realizada co sucesso",
                    usuario
                );
            }
            catch (Exception e)
            {
                //TODO: Implementar serviço de log
                return new ResultadoDaTarefa(
                    false,
                    "Ocorreu um erro ao tentar listar os feeds.",
                    listaDeErros: new[] {e.Message}
                );
            }
        }

        public IResultado ListarFeedUsuario(Guid id, int pagina = 1, int qtdPorPagina = 6)
        {
            try
            {
                var usuario = _repositorioCliente
                    .Queryable()
                    .Include(x => x.Fotos)
                    .FirstOrDefault()
                    .ParaDto(qtdPorPagina);
                
                return new ResultadoDaTarefa(
                    true,
                    "Consulta realizada co sucesso",
                    usuario
                );
            }
            catch (Exception e)
            {
                return new ResultadoDaTarefa(
                    false,
                    "Ocorreu um erro ao tentar listar os feeds do usuário.",
                    listaDeErros: new[] {e.Message}
                );
            }
        }
    }
}