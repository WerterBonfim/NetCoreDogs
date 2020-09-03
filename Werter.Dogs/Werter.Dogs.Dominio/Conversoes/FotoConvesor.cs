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
        public static FotoDto ParaDto(this Foto foto)
        {
            return new FotoDto
            {
                Id = foto.Id,
                Idade = foto.Idade,
                Autor = foto.Usuario.NomeDeUsuario,
                Nome = foto.Nome,
                Peso = foto.Peso,
                QtdAcessos = foto.QuantidadeDeAcessos,
                Extencao = foto.Extencao,
                Src = $"/imagens/{foto.Id.ToString()}.{foto.Extencao}",
                Comentarios = ConverterParaComentariosDtos(foto)
            };
        }

        public static IEnumerable<FotoDto> ParaDto(this IEnumerable<Foto> fotos)
        {
            try
            {
                return fotos.Select(x => new FotoDto
                {
                    Id = x.Id,
                    Idade = x.Idade,
                    Autor = x.Usuario.NomeDeUsuario,
                    Nome = x.Nome,
                    Peso = x.Peso,
                    QtdAcessos = x.QuantidadeDeAcessos,
                    Extencao = x.Extencao,
                    Src = $"/imagens/{x.Id.ToString()}.{x.Extencao}",
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