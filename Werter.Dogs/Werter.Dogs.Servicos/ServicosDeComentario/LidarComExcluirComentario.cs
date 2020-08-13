using System;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Comentario;

namespace Werter.Dogs.Servicos.ServicosDeComentario
{
    public class LidarComExcluirComentario : ITarefa<RequisitosParaExcluirComentario>
    {
        private readonly IRepositorioComentario _repositorioComentario;

        public LidarComExcluirComentario(IRepositorioComentario repositorioComentario)
        {
            _repositorioComentario = repositorioComentario;
        }

        public IResultado LidarCom(RequisitosParaExcluirComentario requisitos)
        {
            try
            {
                if (!requisitos.EValido())
                    return new ResultadoDaTarefa(
                        false,
                        "Dados inválidos para excluir o comentário",
                        listaDeErros: requisitos.ListaErros()
                    );

                var comentario = _repositorioComentario.BuscarPorId(requisitos.Id);
                if (comentario is null)
                    return new ResultadoDaTarefa(false, "Comentário não existe");


                _repositorioComentario.Deletar(requisitos.Id);
                _repositorioComentario.Salvar();

                return new ResultadoDaTarefa(true, "Comentário excluido com sucesso");
            }
            catch (Exception e)
            {
                //TODO: Refatorar para logar esses erros em um sistema de log
                return new ResultadoDaTarefa(
                    false,
                    "Ocorreu um erro interno ao tentar excluir o comentário",
                    listaDeErros: new[] {e.Message}
                );
            }
        }
    }
}