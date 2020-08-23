using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Werter.Dogs.Servicos.Querys.Interfaces;

namespace Werter.Dogs.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IFeedQuery _feedQuery;

        public FeedController(IFeedQuery feedQuery)
        {
            _feedQuery = feedQuery;
        }

        [HttpGet]
        public IActionResult ListarFeed([FromQuery] int pagina = 1)
        {
            var resultado = _feedQuery.ListarFeed();
            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        [HttpGet("usuario/{id:guid}")]
        public IActionResult ListarFeedUsuario([FromRoute]Guid id, [FromQuery]int pagina)
        {
            var resultado = _feedQuery.ListarFeedUsuario(id, 1, 6);
            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }
    }
}