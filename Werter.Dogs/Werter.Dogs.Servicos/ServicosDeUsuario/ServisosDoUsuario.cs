using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos;

namespace Werter.Dogs.Servicos.ServicosDeUsuario
{
    public class ServisosDoUsuario :
        ITarefa<RequisitosParaCriarUsuario>,
        ITarefa<RequisitosParaAtualizarUsuario>,
        ITarefa<RequisitosParaLogin>

    {
        private readonly IRepositorioCliente _clienteRepositorio;
        private readonly ITarefa<RequisitosParaCriarUsuario> _servicoDeCriacaoDeUsuario;
        private readonly ITarefa<RequisitosParaAtualizarUsuario> _servicoDeAtualizacaoDeUsuario;
        private readonly ITarefa<RequisitosParaLogin> _servicoDeLogin;

        public ServisosDoUsuario(IRepositorioCliente repositorioCliente)
        {
            _clienteRepositorio = repositorioCliente;
            _servicoDeCriacaoDeUsuario = new LidarComCriacaoDeUsuario(_clienteRepositorio);
            _servicoDeAtualizacaoDeUsuario = new LidarComAtualizacaoDeUsuario(_clienteRepositorio);
            _servicoDeLogin = new LidarComLoginDoUsuario(_clienteRepositorio);
        }

        public IResultado LidarCom(RequisitosParaAtualizarUsuario requisitos)
        {
            return _servicoDeAtualizacaoDeUsuario.LidarCom(requisitos);
        }

        public IResultado LidarCom(RequisitosParaCriarUsuario requisitos)
        {
            return _servicoDeCriacaoDeUsuario.LidarCom(requisitos);
        }

        public IResultado LidarCom(RequisitosParaLogin requisitos)
        {
            return _servicoDeLogin.LidarCom(requisitos);
        }
    }
}
