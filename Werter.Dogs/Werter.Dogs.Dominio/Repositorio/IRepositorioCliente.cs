using System;
using System.Linq;
using System.Linq.Expressions;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio.Core;

namespace Werter.Dogs.Dominio.Repositorio
{
    public interface IRepositorioCliente : IRepositorioBase<Usuario>
    {
        bool EmailExiste(string email);
        bool NomeDeUsuarioExiste(string nomeDeUsuario);

        IQueryable<Usuario> ListarFeed(int pagina = 1, int qtdUsuario = 3, int qtdFotos = 6,
            params Expression<Func<Usuario, object>>[] includes);
    }
}