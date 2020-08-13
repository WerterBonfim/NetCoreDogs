using System.Linq;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Foto;

namespace Werter.Dogs.Servicos.ServicosDeFoto
{
    public class LidarComIncrementoDeAcessos : ITarefa<RequisitosParaIncrementarAcesso>
    {
        private readonly IRepositorioFoto _repositorioFoto;

        public LidarComIncrementoDeAcessos(IRepositorioFoto repositorioFoto)
        {
            _repositorioFoto = repositorioFoto;
        }

        public IResultado LidarCom(RequisitosParaIncrementarAcesso requisitos)
        {
            if (!requisitos.EValido())
                return new ResultadoDaTarefa(
                    false,
                    "Não foi possivel incrementar o acesso da foto",
                    listaDeErros: requisitos.ListaErros().ToArray()
                );

            _repositorioFoto.IncrementarQtdAcessos(requisitos.Id);

            return new ResultadoDaTarefa(true, "Incrementado com sucesso");
        }
    }
}