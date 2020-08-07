using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos;

namespace Werter.Dogs.Servicos.ServicosDeUsuario
{
    public class ServisosDoUsuario :
        ITarefa<RequisitosParaCriarUsuario>,
        ITarefa<RequisitosParaAtualizarUsuario>

    {
        private readonly IRepositorioCliente _clienteRepositorio;
        private readonly ITarefa<RequisitosParaCriarUsuario> _lidarComCriacaoDeUsuario;
        private readonly ITarefa<RequisitosParaAtualizarUsuario> _lidarComAtualizacaoDeUsuario;

        public ServisosDoUsuario(IRepositorioCliente repositorioCliente)
        {
            _clienteRepositorio = repositorioCliente;
            _lidarComCriacaoDeUsuario = new LidarComCriacaoDeUsuario(_clienteRepositorio);
            _lidarComAtualizacaoDeUsuario = new LidarComAtualizacaoDeUsuario(_clienteRepositorio);
        }

        public IResultado LidarCom(RequisitosParaAtualizarUsuario requisitos)
        {
            return _lidarComAtualizacaoDeUsuario.LidarCom(requisitos);
        }

        public IResultado LidarCom(RequisitosParaCriarUsuario requisitos)
        {
            return _lidarComCriacaoDeUsuario.LidarCom(requisitos);
        }
    }
}
