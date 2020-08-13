using System.Linq;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Foto;

namespace Werter.Dogs.Servicos.ServicosDeFoto
{
    public class LidarComAtualizacaoDeFoto : ITarefa<RequisitosParaAtualizarFoto>
    {
        private readonly IRepositorioFoto _repositorioFoto;

        public LidarComAtualizacaoDeFoto(IRepositorioFoto repositorioFoto)
        {
            _repositorioFoto = repositorioFoto;
        }

        public IResultado LidarCom(RequisitosParaAtualizarFoto requisitos)
        {
            if (!requisitos.EValido())
                return new ResultadoDaTarefa(
                    false,
                    "Ocorreu um erro ao tentar atualizar os dados da foto",
                    listaDeErros: requisitos.ListaErros().ToArray()
                );

            var foto = _repositorioFoto.BuscarPorId(requisitos.Id);
            if (foto is null)
                return new ResultadoDaTarefa(
                    false,
                    "Essa foto não existe");

            foto.AtualizarIdade(requisitos.Idade);
            foto.AtualizarPeso(requisitos.Peso);
            foto.AtualizarNome(requisitos.Nome);

            _repositorioFoto.Atualizar(foto);
            _repositorioFoto.Salvar();

            return new ResultadoDaTarefa(true, "Foto atualizada com sucesso", foto);
        }
    }
}