using System.Linq;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Usuario;

namespace Werter.Dogs.Servicos.ServicosDeUsuario
{
    public class LidarComAtualizacaoDeUsuario : ITarefa<RequisitosParaAtualizarUsuario>
    {
        private readonly IRepositorioCliente _clienteRepositorio;

        public LidarComAtualizacaoDeUsuario(IRepositorioCliente repositorioCliente)
        {
            _clienteRepositorio = repositorioCliente;
        }

        public IResultado LidarCom(RequisitosParaAtualizarUsuario requisitos)
        {
            if (!requisitos.EValido())
                return new ResultadoDaTarefa(
                    false,
                    "Não foi possivel atualizar os dados do usuario",
                    listaDeErros: requisitos.ListaErros()?.ToArray());

            var usuario = _clienteRepositorio.BuscarPorId(requisitos.Id);
            usuario.AtualizarNome(requisitos.Nome);
            AtualizarSenhaCasoFoiInformado(requisitos, usuario);

            _clienteRepositorio.Atualizar(usuario);
            _clienteRepositorio.Salvar();

            return new ResultadoDaTarefa(true, "Usuário atualizado com sucesso");
        }

        private static void AtualizarSenhaCasoFoiInformado(RequisitosParaAtualizarUsuario requisitos, Usuario usuario)
        {
            if (!string.IsNullOrEmpty(requisitos.Senha))
                usuario.AtualizarSenha(requisitos.Senha);
        }
    }
}