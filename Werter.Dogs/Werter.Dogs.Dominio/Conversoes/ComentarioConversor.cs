using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Dominio.Dtos;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Dominio.Conversoes
{
    public static class ComentarioConversor
    {
        public static ComentarioDto ParaDto(this Comentario comentario)
        {
            try
            {
                return new ComentarioDto
                {
                    Id = comentario.Id,
                    Texto = comentario.Texto,
                    DataHora = comentario.DataHoraAlteracao,
                    NomeDeUsuario = comentario.Usuario.NomeDeUsuario
                };
            }
            catch (Exception erro)
            {
                var mensagem = "Ocorreu um erro ao tentar gerar um Dto. De Comentario para ComentarioDto";
                throw new Exception(mensagem, erro);
            }
        }

        public static IEnumerable<ComentarioDto> ParaDto(this ICollection<Comentario> comentarios)
        {
            return comentarios
                .Select(x => x.ParaDto());
        }
    }
}