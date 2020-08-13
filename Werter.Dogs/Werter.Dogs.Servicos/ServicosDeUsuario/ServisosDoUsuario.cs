using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Usuario;

namespace Werter.Dogs.Servicos.ServicosDeUsuario
{
    public class ServisosDoUsuario :
        ITarefa<RequisitosParaCriarUsuario>,
        ITarefa<RequisitosParaAtualizarUsuario>,
        ITarefa<RequisitosParaLogin>

    {
        private readonly IRepositorioCliente _clienteRepositorio;
        private readonly ITarefa<RequisitosParaAtualizarUsuario> _servicoDeAtualizacaoDeUsuario;
        private readonly ITarefa<RequisitosParaCriarUsuario> _servicoDeCriacaoDeUsuario;
        private readonly ITarefa<RequisitosParaLogin> _servicoDeLogin;

        public ServisosDoUsuario(
            IRepositorioCliente repositorioCliente,
            ITarefa<RequisitosParaCriarUsuario> servicoDeCriacaoDeUsuario,
            ITarefa<RequisitosParaAtualizarUsuario> servicoDeAtualizacaoDeUsuario,
            ITarefa<RequisitosParaLogin> servicoDeLogin
        )
        {
            _clienteRepositorio = repositorioCliente;
            _servicoDeCriacaoDeUsuario = servicoDeCriacaoDeUsuario;
            _servicoDeAtualizacaoDeUsuario = servicoDeAtualizacaoDeUsuario;
            _servicoDeLogin = servicoDeLogin;
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