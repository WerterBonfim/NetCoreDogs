using System;
using System.Collections;
using System.Collections.Generic;
using Werter.Dogs.Dominio.Dtos;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio.Core;

namespace Werter.Dogs.Dominio.Repositorio
{
    public interface IRepositorioFoto : IRepositorioBase<Foto>
    {
        void IncrementarQtdAcessos(Guid id);
        IList<EstatisticaDto> BuscarEstatisticaDasFotos(Guid usuarioId);

    }
}