using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Requisitos.Comentario;

namespace Werter.Dogs.Servicos.ServicosDeComentario
{
    public class ServicosDeComentario :
        ITarefa<RequisitosParaCriarComentario>,
        ITarefa<RequisitosParaAlterarComentario>,
        ITarefa<RequisitosParaExcluirComentario>
    {
        public IResultado LidarCom(RequisitosParaCriarComentario requisitos)
        {
            throw new System.NotImplementedException();
        }

        public IResultado LidarCom(RequisitosParaAlterarComentario requisitos)
        {
            throw new System.NotImplementedException();
        }

        public IResultado LidarCom(RequisitosParaExcluirComentario requisitos)
        {
            throw new System.NotImplementedException();
        }
    }
}