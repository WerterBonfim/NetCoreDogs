using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Dominio.Requisitos.Comentario;
using Werter.Dogs.Servicos.Querys.Interfaces;
using Werter.Dogs.Servicos.ServicosDeComentario;

namespace Werter.Dogs.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioQuery _comentarioQuery;
        private readonly ServicosDeComentario _servicosDeComentario;

        public ComentarioController(
            ServicosDeComentario servicosDeComentario,
            IComentarioQuery comentarioQuery
        )
        {
            _servicosDeComentario = servicosDeComentario;
            _comentarioQuery = comentarioQuery;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] RequisitosParaCriarComentario requisitos)
        {
            var resultado = _servicosDeComentario.LidarCom(requisitos);
            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] RequisitosParaAlterarComentario requisitos)
        {
            var resultado = _servicosDeComentario.LidarCom(requisitos);
            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Deletar([FromRoute] RequisitosParaExcluirComentario requisitos)
        {
            var resultado = _servicosDeComentario.LidarCom(requisitos);
            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }


        [AllowAnonymous]
        [HttpGet("foto/{id:guid}")]
        public IActionResult ListarComentariosDaFoto([FromRoute] Guid id)
        {
            try
            {
                var comentarios = _comentarioQuery.ListarComentariosDeUmaFoto(id);
                var resultado = new ResultadoDaTarefa(true, "", comentarios);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                //TODO: Implementar serivo de log
                
                var texto = "Ocorreu um erro interno ao " +
                            "tentar listar os comentário da foto.";
                var resultado = new ResultadoDaTarefa(false, texto);
                return BadRequest(resultado);
            }
        }
    }
}