using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Infra.Contexto;

namespace Werter.Dogs.Infra.Repositorio
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IRepositorioCliente
    {
        public UsuarioRepositorio(DogsContexto contexto) : base(contexto)
        {
        }

        public bool EmailExiste(string email)
        {
            return Contexto.Usuarios
                .AsQueryable()
                .Any(x => x.Email == email);
        }

        public bool NomeDeUsuarioExiste(string nomeDeUsuario)
        {
            return Contexto.Usuarios
                .Any(x => x.NomeDeUsuario == nomeDeUsuario);
        }

        public IQueryable<Usuario> ListarFeed(int pagina = 1, int qtdUsuario = 3, int qtdFotos = 6, params Expression<Func<Usuario, object>>[] includes)
        {
            if (includes == null)
                return Contexto.Usuarios.AsQueryable();

            var query = Contexto.Usuarios.AsQueryable();

            foreach (var item in includes)
                query = query.Include(item);

            return query;
        }
    }
}