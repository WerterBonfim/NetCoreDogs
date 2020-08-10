using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Werter.Dogs.Dominio.Repositorio.Core;
using Werter.Dogs.Infra.Contexto;

namespace Werter.Dogs.Infra.Repositorio
{
    public abstract class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        protected readonly DogsContexto Contexto;

        public RepositorioBase(DogsContexto contexto)
        {
            Contexto = contexto;
        }

        public TEntity BuscarPorId(Guid id)
        {
            return Contexto.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate, params object[] includes)
        {
            return Contexto
                .Set<TEntity>()
                .AsQueryable()
                .Where(predicate);
        }

        public void Atualizar(TEntity entity)
        {
            Contexto.Set<TEntity>().Update(entity);
        }

        public void Inserir(TEntity entity)
        {
            Contexto.Set<TEntity>().Add(entity);
        }

        public List<TEntity> Listar(int pagina = 1, int qtdPorPagina = 5)
        {
            var skip = CalculaSkip(pagina, qtdPorPagina);
            return Contexto.Set<TEntity>()
                .Take(pagina)
                .Skip(skip)
                .ToList();
        }

        public void Salvar()
        {
            Contexto.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var entidade = BuscarPorId(id);
            if (entidade != null)
                Contexto.Set<TEntity>().Remove(entidade);
        }

        private int CalculaSkip(int pagina, int qtdPorPagina)
        {
            var skip = (pagina * qtdPorPagina) - qtdPorPagina;
            return skip;
        }
    }
}