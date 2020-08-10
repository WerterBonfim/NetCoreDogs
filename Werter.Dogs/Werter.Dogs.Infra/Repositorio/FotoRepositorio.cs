using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Infra.Contexto;

namespace Werter.Dogs.Infra.Repositorio
{
    public class FotoRepositorio : IRepositorioFoto
    {
        private readonly DogsContexto _contexto;

        public FotoRepositorio(DogsContexto contexto)
        {
            _contexto = contexto;
        }

        public Foto BuscarPorId(Guid id)
        {
            return _contexto.Fotos.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Foto> Buscar(Expression<Func<Foto, bool>> predicate, params object[] includes)
        {
            return _contexto.Fotos
                .AsQueryable()
                .Where(predicate);
        }

        public void Atualizar(Foto entity)
        {
            _contexto.Fotos.Update(entity);
        }

        public void Inserir(Foto entity)
        {
            _contexto.Fotos.Add(entity);
        }

        public List<Foto> Listar(int pagina = 1, int qtdPorPagina = 5)
        {
            var skip = (pagina * qtdPorPagina) - qtdPorPagina;
            return _contexto.Fotos
                .AsQueryable()
                .Take(qtdPorPagina)
                .Skip(skip)
                .ToList();
        }

        public void Salvar()
        {
            var qtd = _contexto.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var foto = _contexto.Fotos.Find(id);
            if (foto is null)
                return;
            
            _contexto.Fotos.Remove(foto);
        }

        public void IncrementarQtdAcessos(Guid id)
        {
            var foto = BuscarPorId(id);
            foto.IncrementarQtdAcessos();
            Atualizar(foto);
            Salvar();
        }
    }
}