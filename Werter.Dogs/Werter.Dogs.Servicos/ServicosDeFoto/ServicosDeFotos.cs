using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Dominio.Requisitos.Foto;

namespace Werter.Dogs.Servicos.ServicosDeFoto
{
    public class ServicosDeFotos : 
        ITarefa<RequisitosParaCadastrarFoto>,
        ITarefa<RequisitosParaAtualizarFoto>,
        ITarefa<RequisitosParaExcluirFoto>,
        ITarefa<RequisitosParaIncrementarAcesso>
    {
        
        private readonly IRepositorioFoto _repositorioFoto;
        private readonly ITarefa<RequisitosParaCadastrarFoto> _servicoDeCadastroDeFoto;
        private readonly ITarefa<RequisitosParaAtualizarFoto> _servicoDeAtualizacaoDeFoto;
        private readonly ITarefa<RequisitosParaExcluirFoto> _servicoQueExcluiFoto;
        private readonly ITarefa<RequisitosParaIncrementarAcesso> _servicoQueIncrementaAcessos;

        public ServicosDeFotos(
            IRepositorioFoto repositorioFoto,
            ITarefa<RequisitosParaCadastrarFoto> servicoDeCadastroDeFoto,
            ITarefa<RequisitosParaAtualizarFoto> servicoDeAtualizacaoDeFoto,
            ITarefa<RequisitosParaExcluirFoto> servicoQueExcluiFoto,
            ITarefa<RequisitosParaIncrementarAcesso> servicoQueIncrementaAcessos
            )
        {
            _repositorioFoto = repositorioFoto;
            _servicoDeCadastroDeFoto = servicoDeCadastroDeFoto;
            _servicoDeAtualizacaoDeFoto = servicoDeAtualizacaoDeFoto;
            _servicoQueExcluiFoto = servicoQueExcluiFoto;
            _servicoQueIncrementaAcessos = servicoQueIncrementaAcessos;
        }
        public IResultado LidarCom(RequisitosParaCadastrarFoto requisitos)
        {
            return _servicoDeCadastroDeFoto.LidarCom(requisitos);
        }

        public IResultado LidarCom(RequisitosParaAtualizarFoto requisitos)
        {
            return _servicoDeAtualizacaoDeFoto.LidarCom(requisitos);
        }

        public IResultado LidarCom(RequisitosParaExcluirFoto requisitos)
        {
            return _servicoQueExcluiFoto.LidarCom(requisitos);
        }

        public IResultado LidarCom(RequisitosParaIncrementarAcesso requisitos)
        {
            return _servicoQueIncrementaAcessos.LidarCom(requisitos);
        }
    }
}
