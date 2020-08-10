using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Werter.Dogs.Dominio.Requisitos;
using Werter.Dogs.Servicos.ServicosDeUsuario;

namespace Werter.Dogs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ServisosDoUsuario _servisosDoUsuario;
        public UsuarioController(ServisosDoUsuario servisosDoUsuario)
        {
            _servisosDoUsuario = servisosDoUsuario;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Olá", "Mundo" };
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] RequisitosParaCriarUsuario requisitos)
        {
            try
            {
                var resultado = _servisosDoUsuario.LidarCom(requisitos);
                return Ok(resultado);
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Mensagem = "Ocorre um erro grave no servidor: " + erro.Message });
            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult AtualizarUsuario([FromBody] RequisitosParaAtualizarUsuario requisitos)
        {
            try
            {
                var resultado = _servisosDoUsuario.LidarCom(requisitos);
                return Ok(resultado);
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Mensagem = "Ocorre um erro grave no servidor: " + erro.Message });
            }
        }
    }
}
