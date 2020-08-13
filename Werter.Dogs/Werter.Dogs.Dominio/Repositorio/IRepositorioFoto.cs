using System;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Repositorio.Core;

namespace Werter.Dogs.Dominio.Repositorio
{
    public interface IRepositorioFoto : IRepositorioBase<Foto>
    {
        void IncrementarQtdAcessos(Guid id);
    }
}