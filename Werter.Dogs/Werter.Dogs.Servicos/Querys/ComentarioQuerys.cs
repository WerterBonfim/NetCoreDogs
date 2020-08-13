using System;
using System.Collections.Generic;
using System.Linq;
using Werter.Dogs.Dominio.Conversoes;
using Werter.Dogs.Dominio.Dtos;
using Werter.Dogs.Dominio.Repositorio;
using Werter.Dogs.Servicos.Querys.Interfaces;

namespace Werter.Dogs.Servicos.Querys
{
    public class ComentarioQuerys : IComentarioQuery
    {
        private readonly IRepositorioComentario _repositorioComentario;

        public ComentarioQuerys(IRepositorioComentario repositorioComentario)
        {
            _repositorioComentario = repositorioComentario;
        }

        public List<ComentarioDto> ListarComentariosDeUmaFoto(Guid fotoId)
        {
            try
            {
                var comentarios = _repositorioComentario
                    .Buscar(x => x.FotoId == fotoId, "Usuario")
                    .OrderBy(x => x.DataHoraAlteracao)
                    .ToList();

                var comentariosDto = comentarios
                    .ParaDto()
                    .ToList();

                return comentariosDto;
            }
            catch (Exception e)
            {
                //TODO: Implementar logica para logar esses erros em um sistema de log
                throw new Exception("Ocorreu um erro ao tentar listar os comentários de uma foto. Erro Interno: " +
                                    e.Message);
            }
        }
    }
}