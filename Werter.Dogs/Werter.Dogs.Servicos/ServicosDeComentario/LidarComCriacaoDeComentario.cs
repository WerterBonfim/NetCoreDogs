using System;
using System.Linq;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Comentario;

namespace Werter.Dogs.Servicos.ServicosDeComentario
{
    public class LidarComCriacaoDeComentario : ITarefa<RequisitosParaCriarComentario>
    {
        private readonly IRepositorioComentario _repositorioComentario;

        public LidarComCriacaoDeComentario(IRepositorioComentario repositorioComentario)
        {
            _repositorioComentario = repositorioComentario;
        }

        public IResultado LidarCom(RequisitosParaCriarComentario requisitos)
        {
            try
            {
                if (!requisitos.EValido())
                    return new ResultadoDaTarefa(
                        false,
                        "Ocorreu um erro ao tentar criar um comentário",
                        listaDeErros: requisitos.ListaErros().ToArray()
                    );

                var comentario = new Comentario(requisitos.FotoId, requisitos.UsuarioId, requisitos.Texto);
                _repositorioComentario.Inserir(comentario);
                _repositorioComentario.Salvar();

                return new ResultadoDaTarefa(
                    true,
                    "Mensagem cadastrada com sucesso"
                );
            }
            catch (Exception e)
            {
                return new ResultadoDaTarefa(
                    false,
                    "Ocorre um erro interno ao tentar inserir um novo comentário",
                    listaDeErros: new[] {e.Message}
                );
            }
        }
    }
}