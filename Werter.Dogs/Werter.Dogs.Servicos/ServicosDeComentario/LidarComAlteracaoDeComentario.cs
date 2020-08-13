using System;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Comentario;

namespace Werter.Dogs.Servicos.ServicosDeComentario
{
    public class LidarComAlteracaoDeComentario : ITarefa<RequisitosParaAlterarComentario>
    {
        private readonly IRepositorioComentario _repositorioComentario;

        public LidarComAlteracaoDeComentario(IRepositorioComentario repositorioComentario)
        {
            _repositorioComentario = repositorioComentario;
        }

        public IResultado LidarCom(RequisitosParaAlterarComentario requisitos)
        {
            try
            {
                if (!requisitos.EValido())
                    return new ResultadoDaTarefa(
                        false,
                        "Dados inválidos para alterar um comentário",
                        listaDeErros: requisitos.ListaErros()
                    );

                var comentario = _repositorioComentario.BuscarPorId(requisitos.Id);
                if (comentario is null)
                    return new ResultadoDaTarefa(false, "Comentário não existe");

                comentario.AtualizarComentario(requisitos.Texto);
                _repositorioComentario.Atualizar(comentario);
                _repositorioComentario.Salvar();

                return new ResultadoDaTarefa(true, "Comentário atualizado com sucesso");
            }
            catch (Exception e)
            {
                //TODO: Refatorar para logar esses erros em um sistema de log
                return new ResultadoDaTarefa(
                    false,
                    "Ocorreu um erro interno ao tentar atualizar o comentário",
                    listaDeErros: new[] {e.Message}
                );
            }
        }
    }
}