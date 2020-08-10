using System;
using System.Collections.Generic;
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
        new IQueryable<Usuario> Buscar(Expression<Func<Usuario, bool>> predicate, params object[] includes);
        new Usuario BuscarPorId(Guid id);
        new void Atualizar(Usuario usuario);
    }
}
