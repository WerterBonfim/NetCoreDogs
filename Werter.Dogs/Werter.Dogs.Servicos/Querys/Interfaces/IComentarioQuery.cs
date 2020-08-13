using System;
using System.Collections.Generic;
using Werter.Dogs.Dominio.Dtos;

namespace Werter.Dogs.Servicos.Querys.Interfaces
{
    public interface IComentarioQuery : IQuery
    {
        public List<ComentarioDto> ListarComentariosDeUmaFoto(Guid fotoId);
    }
}