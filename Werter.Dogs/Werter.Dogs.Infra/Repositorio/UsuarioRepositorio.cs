using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Infra.Contexto;

namespace Werter.Dogs.Infra.Repositorio
{
    public class UsuarioRepositorio : IRepositorioCliente
    {
        private readonly DogsContexto _dbContext;

        public UsuarioRepositorio(DogsContexto contexto)
        {
            _dbContext = contexto;
        }

        public void Atualizar(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);            
        }

        public List<Usuario> Buscar(Expression<Func<Usuario, bool>> predicate, params object[] includes)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _dbContext.Usuarios.Find(id);
        }

        public bool EmailExiste(string email)
        {
            return _dbContext.Usuarios
                .Where(x => x.Email == email)
                .Any();
        }

        public void Inserir(Usuario entity)
        {
            _dbContext.Usuarios.Add(entity);
            
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }

        public bool NomeDeUsuarioExiste(string nomeDeUsuario)
        {
            return _dbContext.Usuarios
                .Where(x => x.NomeDeUsuario == nomeDeUsuario)
                .Any();
        }

        public void Salvar()
        {
            _dbContext.SaveChanges();
        }
    }
}
