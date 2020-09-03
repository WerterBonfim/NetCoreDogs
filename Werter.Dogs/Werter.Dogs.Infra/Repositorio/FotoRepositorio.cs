using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public override Foto BuscarPorId(Guid id)
        {
            var foto = Contexto.Fotos
                .AsQueryable()
                .Include(x => x.Usuario)
                .FirstOrDefault(x => x.Id == id);

            return foto;
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