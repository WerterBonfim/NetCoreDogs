using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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

        public virtual TEntity BuscarPorId(Guid id)
        {
            return Contexto.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            IQueryable<TEntity> contexto = Contexto.Set<TEntity>();

            foreach (var entity in includes)
                contexto.Include(entity)
                    .Load();

            return contexto
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

        public IQueryable<TEntity> Queryable()
        {
            return Contexto.Set<TEntity>()
                .AsQueryable()
                .AsNoTracking();
        }

        public int CalculaSkip(int pagina, int qtdPorPagina)
        {
            var skip = pagina * qtdPorPagina - qtdPorPagina;
            return skip;
        }
    }
}