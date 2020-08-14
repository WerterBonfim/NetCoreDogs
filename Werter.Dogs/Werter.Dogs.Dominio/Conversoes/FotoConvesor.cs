using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Dominio.Dtos;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Dominio.Conversoes
{
    public static class FotoConvesor
    {
        public static IEnumerable<FotoDto> ParaDto(this IEnumerable<Foto> fotos)
        {
            try
            {
                return fotos.Select(x => new FotoDto
                {
                    Id = x.Id,
                    Idade = x.Idade,
                    Nome = x.Nome,
                    Peso = x.Peso,
                    QtdAcessos = x.QuantidadeDeAcessos,
                    Comentarios = ConverterParaComentariosDtos(x)
                });
            }
            catch (Exception erro)
            {
                var mensagem = "Ocorreu um erro ao tentar gerar um Dto. De Foto para FotoDto";
                throw new Exception(mensagem, erro);
            }
        }

        private static List<ComentarioDto> ConverterParaComentariosDtos(Foto x)
        {
            return x.Comentarios == null ? new List<ComentarioDto>() : x.Comentarios.ParaDto().ToList();
        }
    }
}