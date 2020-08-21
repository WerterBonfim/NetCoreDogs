using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Werter.Dogs.Dominio.Entidades;
using Werter.Dogs.Dominio.Requisitos.Usuario;
using Werter.Dogs.Servicos.ServicosDeUsuario;
using Werter.Dogs.WebApi.Configuracoes.Seguranca;
using Werter.Dogs.WebApi.ViewModel;

namespace Werter.Dogs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ServisosDoUsuario _servisosDoUsuario;

        public TokenController(ServisosDoUsuario servisosDoUsuario)
        {
            _servisosDoUsuario = servisosDoUsuario;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("auth")]
        public IActionResult Post(
            [FromBody] RequisitosParaLogin requisitos,
            [FromServices] ConfiguracaoDeAutenticacao configuracaoDeAutenticacao,
            [FromServices] ConfiguracaoDoToken configuracaoDoToken
        )
        {
            var resultado = _servisosDoUsuario.LidarCom(requisitos);
            if (!resultado.Sucesso)
                return BadRequest(resultado);

            var usuario = ((Usuario) resultado.Dados).ParaViewModel();

            var usuarioId = usuario.Id.ToString();

            var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioId)
                }
            );

            var dtCriacao = DateTime.Now;
            var dtExpiracao = dtCriacao + TimeSpan.FromMinutes(configuracaoDoToken.Minutos);

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = configuracaoDoToken.Issuer,
                Audience = configuracaoDoToken.Audience,
                SigningCredentials = configuracaoDeAutenticacao.Credenciais,
                Subject = identity,
                NotBefore = dtCriacao,
                Expires = dtExpiracao
            });
            ;
            var token = handler.WriteToken(securityToken);

            var autenticacao = new
            {
                autenticado = true,
                usuario,
                criado = dtCriacao.ToString("yyy-mm-dd HH:mm:ss"),
                expiracao = dtExpiracao.ToString("yyyy-mm-dd HH:mm:ss"),
                tokenDeAcesso = token,
                mensagem = "OK"
            };

            return Ok(autenticacao);
        }
    }
}