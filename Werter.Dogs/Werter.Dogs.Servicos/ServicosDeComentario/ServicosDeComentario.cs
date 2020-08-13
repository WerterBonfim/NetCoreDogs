using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Requisitos.Comentario;

namespace Werter.Dogs.Servicos.ServicosDeComentario
{
    public class ServicosDeComentario :
        ITarefa<RequisitosParaCriarComentario>,
        ITarefa<RequisitosParaAlterarComentario>,
        ITarefa<RequisitosParaExcluirComentario>
    {
        private readonly ITarefa<RequisitosParaAlterarComentario> _servicoAlterarComentario;
        private readonly ITarefa<RequisitosParaCriarComentario> _servicoCriarComentario;
        private readonly ITarefa<RequisitosParaExcluirComentario> _servicoExcluirComentario;

        public ServicosDeComentario(
            ITarefa<RequisitosParaCriarComentario> servicoCriarComentario,
            ITarefa<RequisitosParaAlterarComentario> servicoAlterarComentario,
            ITarefa<RequisitosParaExcluirComentario> servicoExcluirComentario
        )
        {
            _servicoCriarComentario = servicoCriarComentario;
            _servicoAlterarComentario = servicoAlterarComentario;
            _servicoExcluirComentario = servicoExcluirComentario;
        }

        public IResultado LidarCom(RequisitosParaAlterarComentario requisitos)
        {
            return _servicoAlterarComentario.LidarCom(requisitos);
        }


        public IResultado LidarCom(RequisitosParaCriarComentario requisitos)
        {
            return _servicoCriarComentario.LidarCom(requisitos);
        }

        public IResultado LidarCom(RequisitosParaExcluirComentario requisitos)
        {
            return _servicoExcluirComentario.LidarCom(requisitos);
        }
    }
}