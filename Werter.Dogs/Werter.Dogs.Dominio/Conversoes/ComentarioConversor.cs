using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Dominio.Dtos;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Dominio.Conversoes
{
    public static class ComentarioConversor
    {
        public static IEnumerable<ComentarioDto> ParaDto(this ICollection<Comentario> comentarios)
        {
            try
            {
                return comentarios
                    .Select(x => new ComentarioDto
                        {
                            Id = x.Id,
                            Texto = x.Texto,
                            DataHora = x.DataHoraAlteracao,
                            NomeDeUsuario = x.Usuario.NomeDeUsuario
                        }
                    );
            }
            catch (Exception erro)
            {
                var mensagem = "Ocorreu um erro ao tentar gerar um Dto. De Comentario para ComentarioDto";
                throw new Exception(mensagem, erro);
            }
            
        }
    }
}