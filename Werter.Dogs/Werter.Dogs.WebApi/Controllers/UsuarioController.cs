using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Werter.Dogs.Dominio.Requisitos;
using Werter.Dogs.Servicos.ServicosDeUsuario;

namespace Werter.Dogs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly LidarComCriacaoDeUsuario _lidarComCriacaoDeUsuario;
        public UsuarioController(LidarComCriacaoDeUsuario lidarComCriacaoDeUsuario)
        {
            _lidarComCriacaoDeUsuario = lidarComCriacaoDeUsuario;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Olá", "Mundo" };
        }

        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] RequisitosParaCriarUsuario requisitos)
        {
            try
            {
                var resultado = _lidarComCriacaoDeUsuario.LidarCom(requisitos);
                return Ok(resultado);
            }
            catch (Exception erro)
            {
                return StatusCode(500, new { Mensagem = "Ocorre um erro grave no servidor: " + erro.Message });
            }
        }
    }
}
