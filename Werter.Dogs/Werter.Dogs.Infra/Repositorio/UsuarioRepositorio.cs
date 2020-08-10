using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Usuario> Buscar(Expression<Func<Usuario, bool>> predicate, params object[] includes)
        {
            return _dbContext.Usuarios
                .AsQueryable()
                .Where(predicate);
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _dbContext.Usuarios.Find(id);
        }

        public bool EmailExiste(string email)
        {
            return _dbContext.Usuarios
                .AsQueryable()
                .Any(x => x.Email == email);
        }

        public void Inserir(Usuario entity)
        {
            _dbContext.Usuarios.Add(entity);
            
        }

        public List<Usuario> Listar(int pagina = 1, int qtdPorPagina = 5)
        {
            var skip = (pagina * qtdPorPagina) - qtdPorPagina;
            return _dbContext.Usuarios
                .AsQueryable()
                .Take(qtdPorPagina)
                .Skip(skip)
                .ToList();
        }

        public bool NomeDeUsuarioExiste(string nomeDeUsuario)
        {
            return _dbContext.Usuarios
                .Any(x => x.NomeDeUsuario == nomeDeUsuario);
        }

        public void Salvar()
        {
            _dbContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var usuario = _dbContext.Usuarios.Find(id);
            if (usuario is null)
                return;
            
            _dbContext.Usuarios.Remove(usuario);
        }
    }
}
