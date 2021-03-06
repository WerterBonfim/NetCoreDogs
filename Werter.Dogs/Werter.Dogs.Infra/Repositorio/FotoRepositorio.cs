using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Werter.Dogs.Dominio.Dtos;
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

        public IList<EstatisticaDto> BuscarEstatisticaDasFotos(Guid usuarioId)
        {
            var estatisticas = Contexto
                .Fotos
                .AsNoTracking()
                .AsQueryable()
                .Where(x => x.UsuarioId == usuarioId && x.QuantidadeDeAcessos > 0)
                .Select(x => new EstatisticaDto(x.Id, x.Nome, x.QuantidadeDeAcessos))
                .ToList();

            return estatisticas;
        }
    }
}