using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Werter.Dogs.WebApi.Seguranca
{
    public class AutenticacaoBasica
    {
        public async Task Invoke(HttpContext context)
        {
            var x = context.Request.Headers.GetCommaSeparatedValues("Authorization");
            
        }
    }
}
