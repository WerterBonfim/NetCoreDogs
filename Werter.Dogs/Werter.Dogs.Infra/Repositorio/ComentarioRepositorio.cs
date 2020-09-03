using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public override Comentario BuscarPorId(Guid id)
        {
            return Contexto.Comentarios
                .AsNoTracking()
                .AsQueryable()
                .Include(x => x.Usuario)
                .FirstOrDefault(x => x.Id == id);

        }
    }
}