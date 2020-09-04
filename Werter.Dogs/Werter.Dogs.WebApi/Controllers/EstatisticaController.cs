using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Werter.Dogs.Compartilhado;
using Werter.Dogs.Dominio.Repositorio;

namespace Werter.Dogs.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EstatisticaController : ControllerBase
    {
        private readonly IRepositorioFoto _repositorioFoto;

        public EstatisticaController(IRepositorioFoto repositorioFoto)
        {
            _repositorioFoto = repositorioFoto;
        }

        [HttpGet("{id:guid}")]
        public IActionResult DoUsuario([FromRoute] Guid id)
        {
            try
            {
                var estatisticas = _repositorioFoto.BuscarEstatisticaDasFotos(id);
                return Ok(new ResultadoDaTarefa(true, "Busca realizada com sucesso", estatisticas));
            }
            catch (Exception e)
            {
                //TODO: Log aqui
                var mensagem = e.Message;
                return BadRequest(new ResultadoDaTarefa(
                    false,
                    "Ocorreu um erro ao tentar buscar as estatisticas"));
            }
        }
    }
}