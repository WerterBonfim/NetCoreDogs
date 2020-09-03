using System;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Compartilhado.Interfaces;
using Werter.Dogs.Dominio.Conversoes;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Servicos.Querys.Interfaces;

namespace Werter.Dogs.Servicos.Querys
{
    public class FotoQuery : IFotoQuery
    {
        private readonly IRepositorioFoto _repositorioFoto;

        public FotoQuery(IRepositorioFoto repositorioFoto)
        {
            _repositorioFoto = repositorioFoto;
        }

        public IResultado BuscarFoto(Guid fotoId, int qtdComentarios = 10)
        {
            var foto = _repositorioFoto.BuscarPorId(fotoId);

            if (foto == null)
                return new ResultadoDaTarefa(
                    false,
                    "Foto não existe"
                );


            var fotoDto = foto.ParaDto();
            return new ResultadoDaTarefa(true, "Foto carregada com sucesso", fotoDto);
        }
    }
}