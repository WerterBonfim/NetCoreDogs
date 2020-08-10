using System.Linq;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Foto;

namespace Werter.Dogs.Servicos.ServicosDeFoto
{
    public class LidarComExcluirFoto : ITarefa<RequisitosParaExcluirFoto>
    {
        private readonly IRepositorioFoto _repositorioFoto;

        public LidarComExcluirFoto(IRepositorioFoto repositorioFoto)
        {
            _repositorioFoto = repositorioFoto;
        }

        public IResultado LidarCom(RequisitosParaExcluirFoto requisitos)
        {
            if (!requisitos.EValido())
                return new ResultadoDaTarefa(
                    false,
                    "Ocorreu um erro ao tentar excluir a foto",
                    listaDeErros: requisitos.ListaErros().ToArray()
                );

            _repositorioFoto.Deletar(requisitos.Id);
            _repositorioFoto.Salvar();
            
            return new ResultadoDaTarefa(true, "Foto deletada com sucesso");
        }
    }
}