using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Werter.Dogs.WebApi.Seguranca;

namespace Werter.Dogs.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        
        [AllowAnonymous]
        [HttpPost]
        [Route("auth")]
        public IActionResult Post(
            
            [FromServices]ConfiguracaoDeAutenticacao configuracaoDeAutenticacao,
            [FromServices]ConfiguracaoDoToken configuracaoDoToken
            )
        {
            var userId = "userId";
            
            // var identity = new ClaimsIdentity(
            //         new GenericIdentity()
            //     );
            
            
            return null;
        }
    }
}