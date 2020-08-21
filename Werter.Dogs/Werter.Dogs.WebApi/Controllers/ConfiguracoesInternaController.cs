using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Werter.Dogs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracoesInternaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfiguracoesInternaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult Informacoes()
        {
            var dados = new
            {
                StringDeConexao = Environment.GetEnvironmentVariables()
            };

            return Ok(dados);
        }
    }
    

}