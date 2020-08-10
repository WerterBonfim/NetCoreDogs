using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Infra.Contexto;

namespace Werter.Dogs.Infra.Repositorio
{
    public class ComentarioRepositorio : RepositorioBase<Comentario>, IRepositorioComentario
    {
        public ComentarioRepositorio(DogsContexto contexto) : base(contexto)
        {
        }
    }
}