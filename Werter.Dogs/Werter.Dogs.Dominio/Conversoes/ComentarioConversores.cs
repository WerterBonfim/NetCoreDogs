using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Dominio.Dtos;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Dominio.Conversoes
{
    public static class ComentarioConversores
    {
        public static IEnumerable<ComentarioDto> ParaDto(this IList<Comentario> comentarios)
        {
            return comentarios
                .Select(x => new ComentarioDto
                    {
                        ComentarioId = x.Id,
                        Texto = x.Texto,
                        DataHora = x.DataHoraAlteracao,
                        NomeDeUsuario = x.Usuario.NomeDeUsuario
                    }
                );
        }
    }
}