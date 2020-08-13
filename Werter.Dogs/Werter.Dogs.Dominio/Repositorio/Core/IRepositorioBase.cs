using System;
using System.Collections.Generic;
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

        List<TEntity> Listar(int pagina = 1, int qtdPorPagina = 5);
        void Salvar();
        void Deletar(Guid id);
    }
}