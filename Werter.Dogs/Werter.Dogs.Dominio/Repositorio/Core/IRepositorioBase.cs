using System;
using System.Linq;
using System.Linq.Expressions;

namespace Werter.Dogs.Dominio.Repositorio.Core
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        TEntity BuscarPorId(Guid id);
        IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate, params string[] includes);
        void Atualizar(TEntity entity);
        void Inserir(TEntity entity);
        void Salvar();
        void Deletar(Guid id);
        IQueryable<TEntity> Queryable();
        int CalculaSkip(int pagina, int qtdPorPagina);
    }
}