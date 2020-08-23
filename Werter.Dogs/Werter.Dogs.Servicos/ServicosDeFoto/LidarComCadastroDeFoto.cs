using System.Linq;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Foto;

namespace Werter.Dogs.Servicos.ServicosDeFoto
{
    public class LidarComCadastroDeFoto : ITarefa<RequisitosParaCadastrarFoto>
    {
        private readonly IRepositorioFoto _repositorioFoto;

        public LidarComCadastroDeFoto(IRepositorioFoto repositorioFoto)
        {
            _repositorioFoto = repositorioFoto;
        }

        public IResultado LidarCom(RequisitosParaCadastrarFoto requisitos)
        {
            if (!requisitos.EValido())
                return new ResultadoDaTarefa(
                    false,
                    "Não foi possivel cadastrar a foto",
                    listaDeErros: requisitos.ListaErros().ToArray()
                );

            var foto = new Foto(requisitos.Nome, requisitos.Peso, requisitos.Idade, requisitos.UsuarioId, requisitos.Extencao);
            _repositorioFoto.Inserir(foto);
            _repositorioFoto.Salvar();

            return new ResultadoDaTarefa(true, "Foto cadastra com sucesso", foto);
        }
    }
}