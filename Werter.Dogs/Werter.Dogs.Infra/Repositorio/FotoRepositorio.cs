using System;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Infra.Contexto;

namespace Werter.Dogs.Infra.Repositorio
{
    public class FotoRepositorio : RepositorioBase<Foto>, IRepositorioFoto
    {
        public FotoRepositorio(DogsContexto contexto) : base(contexto)
        {
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