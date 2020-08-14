using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Dominio.Dtos;
using Werter.Dogs.Dominio.Entidades;

namespace Werter.Dogs.Dominio.Conversoes
{
    public static class UsuarioConversor
    {
        public static UsuarioDto ParaDto(this Usuario usuario, int? takeFotos = null)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                NomeDeUsuario = usuario.NomeDeUsuario,
                Fotos = ConverterParaFotosDto(usuario, takeFotos)
            };
        }
        
        public static IEnumerable<UsuarioDto> ParaDto(this ICollection<Usuario> usuarios)
        {
            try
            {
                return usuarios
                    .Select(x => x.ParaDto());
            }
            catch (Exception erro)
            {
                var mensagem = "Ocorreu um erro ao tentar gerar um Dto. De Usuario para Usuario Dto";
                throw new Exception(mensagem, erro);
            }
        }

        private static List<FotoDto> ConverterParaFotosDto(Usuario x, int? take = null)
        {
            if (take == null)
                return x.Fotos == null ? new List<FotoDto>() : x.Fotos.ParaDto().ToList();
            
            if (x.Fotos == null)
                return  new List<FotoDto>();

            return x.Fotos
                //TODO: Incluir a propriedade DtHoraCriacao
                .OrderBy(x => x.DataHoraAlteracao)
                .Take(take.Value)
                .ParaDto()
                .ToList();
        }
    }
}